using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
   public class OrderSearch
    {

        public DateTime OrderDate { get; set; }
        public ICollection<ProductOrder> OrderProducts { get; set; }
    }
}
