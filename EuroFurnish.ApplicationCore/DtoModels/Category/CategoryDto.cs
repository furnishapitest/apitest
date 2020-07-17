using EuroFurnish.ApplicationCore.DtoModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.DtoModels.Category
{
    public class CategoryDto : BaseDtoModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
