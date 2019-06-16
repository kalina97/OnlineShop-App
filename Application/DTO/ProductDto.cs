using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        [RegularExpression("^[A-Z][a-z0-9]{2,30}$", ErrorMessage = "Invalid name format.")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AvailableCount { get; set; }
        [Required]
        public int BrandId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageSrc { get; set; }
        public IEnumerable<string> CategoryNames { get; set; }
       

    }
}
