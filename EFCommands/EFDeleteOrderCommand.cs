using Application.Commands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFDeleteOrderCommand : BaseEFCommand, IDeleteOrderCommand
    {
        public EFDeleteOrderCommand(OnlineShopContext context) : base(context)
        {
        }
        public void Execute(int request)
        {
            var order = Context.Orders.Find(request);
            if (order == null)
            {
                throw new EntityNotFoundException("Order");
            }

            Context.Orders.Remove(order);

            Context.SaveChanges();

        }


    }
}
