using System;
using System.Collections;
using System.Collections.Generic;

namespace Application.Entites
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<HeroAttribute> Attributes { get; set; }

        public Hero()
        {
            Attributes = new List<HeroAttribute>();
        }

        public double WinRate { get; set; }

    }
}
