using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class ProductSearch
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}
