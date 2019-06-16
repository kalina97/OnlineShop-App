using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.UploadProduct
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int AvailableCount { get; set; }

        public int BrandId { get; set; }

        public decimal Price { get; set; }

        public IFormFile ImageSrc { get; set; }
    }
}
