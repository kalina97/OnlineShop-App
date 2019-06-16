using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;


namespace Application.DTO
{
    public class ProductWebDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [RegularExpression("^[0-9]{1,5}$", ErrorMessage = "Invalid AvailableCount format.")]
        public int AvailableCount { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public Brand Brand { get; set; }

        [Required]
        [RegularExpression("^[0-9]+.[0-9]{1,2}$", ErrorMessage = "Invalid Price format.")]
        public decimal Price { get; set; }

        public string ImageSrc { get; set; }
        public IEnumerable<string> CategoryNames { get; set; }
    }
}
