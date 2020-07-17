using EuroFurnish.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class Country : BaseEntity
    {
        public Country(string name, string code, string description)
        {
            Name = name;
            Code = code;
            Description = description;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
