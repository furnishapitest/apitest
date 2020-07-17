using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EuroFurnish.ApplicationCore.Specifications
{
    public class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(long productId):base(p=>p.Id>productId)
        {
            ApplyPaging(5, 5);
           AddInclude(i => i.Category);
        }
        public ProductWithCategorySpecification():base(null)
        {
            AddInclude(i => i.Category);
        }
    }
}
