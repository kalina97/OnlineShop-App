using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ProductOrderDto
    {

        [Required]
        public int ProductId { get; set; }
        [Required]
        public int OrderId { get; set; }
       
        public Product Product { get; set; }
      
        public Order Order { get; set; }


    }
}
