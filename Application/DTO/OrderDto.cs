using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public IEnumerable<ProductOrderDto> OrderProducts { get; set; }


    }
}
