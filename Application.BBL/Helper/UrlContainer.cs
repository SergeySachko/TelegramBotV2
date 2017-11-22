using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.BBL
{
    public class UrlContainer
    {
        public string AllHeroesURL { get; set; }

        public string ItemsURL { get; set; }

        public string BaseURL { get; set; }

        public UrlContainer(string baseUrl,string allHeroesURL)
        {
            BaseURL = baseUrl;
            AllHeroesURL = allHeroesURL; 
        }

    }
}
