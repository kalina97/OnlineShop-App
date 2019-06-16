using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
