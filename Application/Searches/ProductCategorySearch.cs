using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class ProductCategorySearch
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
