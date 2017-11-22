using Application.BBLInteface;
using Application.DAL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Application.Entites;

namespace Application.BBL
{
    public class DataFactory : IDataFactory
    {
        private readonly IDbContextFactory dbFactory;
        private readonly IServiceProvider serviceProvider;

        public DataFactory(IDbContextFactory _dbFactory, IServiceProvider _serviceProvider)
        {
            dbFactory = _dbFactory;
            serviceProvider = _serviceProvider;
        }
        
        public void UpdateHeroesInfo()
        {
            var setting = (UrlContainer)serviceProvider.GetService(typeof(UrlContainer));           
            var web = new HtmlWeb();
            var doc = web.Load(setting.AllHeroesURL);
            //Get all Heroes from page
            var listOfHeroes = doc.DocumentNode.Descendants("div").Where(d=>d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("hero-grid")).FirstOrDefault();
            if (listOfHeroes != null)
            {
                foreach (var node in listOfHeroes.ChildNodes)
                {
                    // Get url of hero 
                    if (node.Name != "a")
                        continue;
                    var currentHeroUrl = node.Attributes["href"];

                    UpdateHeroesInfoTable(setting.BaseURL + currentHeroUrl.Value);
                }
            }
        }

        public void UpdateItems()
        {
            throw new NotImplementedException();
        }

        // Get Page of Hero and parse it 
        private void UpdateHeroesInfoTable(string heroURL)
        {
            var web = new HtmlWeb();
            var doc = web.Load(heroURL);
            Hero hero = new Hero();

            string heroNameHtml = doc.DocumentNode.Descendants("div").Where(d=>d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("header-content-title")).FirstOrDefault().InnerHtml;

            int indexStartOfH1 = heroNameHtml.IndexOf("<");
            int indexEndOfh1 = heroNameHtml.IndexOf(">");
            int indexOfUselessText = heroNameHtml.IndexOf("<small>");

            hero.Name = heroNameHtml.Remove(indexOfUselessText).Remove(indexStartOfH1, indexEndOfh1 - indexStartOfH1 + 1);
            hero.WinRate = double.Parse(doc.DocumentNode.Descendants("span").Where(w => w.Attributes.Contains("class") && (w.Attributes["class"].Value.Contains("won") || w.Attributes["class"].Value.Contains("lost"))).FirstOrDefault().InnerText.Trim('%'));

            List<HeroAttribute> listOfHeroAttribute = new List<HeroAttribute>();

            var heroAttributes = doc.DocumentNode.Descendants("section").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("hero_attributes")).FirstOrDefault();
            var articleNode= heroAttributes.Descendants("article").FirstOrDefault();
            var mainAttributes = articleNode.Descendants("table").Where(t => t.Attributes["class"].Value.Contains("main")).FirstOrDefault().Descendants("tr").Skip(1).FirstOrDefault();

            //Add Base Attribute
            foreach(var item in mainAttributes.Descendants("td"))
            {
                if (item.Attributes["class"].Value.Contains("str"))
                    listOfHeroAttribute.Add(new HeroAttribute()
                    {
                        IsMainAttribute = IsMainAttribute(articleNode, "primary-strength"),
                        Name = "Strength",
                        Value = item.InnerText,
                        Hero = hero
                    });
                else if (item.Attributes["class"].Value.Contains("agi"))
                    listOfHeroAttribute.Add(new HeroAttribute()
                    {
                        IsMainAttribute = IsMainAttribute(articleNode, "primary-agility"),
                        Name = "Agility",
                        Value = item.InnerText,
                        Hero = hero
                    });
                else
                    listOfHeroAttribute.Add(new HeroAttribute()
                    {
                        IsMainAttribute = IsMainAttribute(articleNode, "primary-intelligence"),
                        Name = "Intelligence",
                        Value = item.InnerText,
                        Hero = hero
                    });
            }

            var otherAttributes = articleNode.Descendants("table").Where(t => t.Attributes["class"].Value.Contains("other")).FirstOrDefault().Descendants("tr");

            foreach(var item in otherAttributes)
            {
                listOfHeroAttribute.Add(new HeroAttribute()
                {
                    Hero = hero,
                    IsMainAttribute = false,
                    Name = item.Descendants("td").ElementAt(0).InnerText,
                    Value = item.Descendants("td").ElementAt(1).InnerText
                });
            }

            using(var context = dbFactory.Create())
            {
                context.Heroes.Add(hero);
                context.HeroAttributes.AddRange(listOfHeroAttribute);
                context.SaveChanges();
            }
        }

        private bool IsMainAttribute(HtmlNode articleNode,string classValue)
        {
            return articleNode.Descendants("tbody").FirstOrDefault().Attributes["class"].Value.Contains(classValue);
        }

    }
}
