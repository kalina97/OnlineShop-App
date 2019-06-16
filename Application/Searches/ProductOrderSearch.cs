using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class ProductOrderSearch
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
