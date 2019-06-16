using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class BrandDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This is Required field")]
        [MinLength(2, ErrorMessage = "Brand name must have at least 2 characters.")]
        public string BrandName { get; set; }
    }
}
