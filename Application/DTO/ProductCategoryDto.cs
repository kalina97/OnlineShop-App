using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ProductCategoryDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
      
        public Category Category { get; set; }
        
        public Product Product { get; set; }
    }
}
