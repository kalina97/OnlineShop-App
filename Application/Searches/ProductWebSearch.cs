using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class ProductWebSearch
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
    }
}
