using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }

        public string ImageSrc { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }



    }
}
