using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }

        public int Quantity { get; set; }

        public User User { get; set; }

        public ICollection<ProductOrder> OrderProducts { get; set; }


    }
}
