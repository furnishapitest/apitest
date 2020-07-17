using EuroFurnish.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class City : BaseEntity
    {
        public City(string name, string description, long countryId)
        {
            Name = name;
            Description = description;
            CountryId = countryId;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public long CountryId { get; set; }
        public Country Country { get; set; }
    }
}
