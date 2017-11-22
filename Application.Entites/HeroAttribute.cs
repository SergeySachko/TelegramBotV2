using System;

namespace Application.Entites
{
    public class HeroAttribute
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool IsMainAttribute { get; set; }

        public int? HeroId { get; set; }

        public virtual Hero Hero { get; set; }

    }
}
