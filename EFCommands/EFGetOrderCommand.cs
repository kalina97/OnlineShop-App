using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFGetOrderCommand : BaseEFCommand, IGetOrderCommand
    {
        public EFGetOrderCommand(OnlineShopContext context) : base(context)
        {
        }

        public OrderDto Execute(int request)
        {
            var order = Context.Orders.Find(request);

            if (order == null)
                throw new EntityNotFoundException("Order");

            return new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                Quantity = order.Quantity
               




            };

        }
    }
}
