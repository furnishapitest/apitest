using EuroFurnish.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class ProductImage : BaseEntity
    {
        public ProductImage(string path, string extension, bool mainImage, long productId)
        {
            Path = path;
            Extension = extension;
            MainImage = mainImage;
            ProductId = productId;
        }
        public string Path { get; set; }
        public string Extension { get; set; }
        public bool MainImage { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
