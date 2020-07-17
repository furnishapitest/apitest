using EuroFurnish.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class Category : BaseEntity
    {
        public Category(string name, string code, string description)
        {
            Name = name;
            Code = code;
            Description = description;
        }
        public Category() { }
        
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
