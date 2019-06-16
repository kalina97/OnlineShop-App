using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category : BaseEntity
    {

        public string Name { get; set; }
        public ICollection<ProductCategory> CategoryProducts { get; set; }
    }
}
