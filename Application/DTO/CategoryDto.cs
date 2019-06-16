using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This is Required field")]
        [MinLength(3, ErrorMessage = "Category name must have at least 3 characters.")]
        public string Name { get; set; }
        public ICollection<ProductCategoryDto> Products { get; set; }
    }
}
