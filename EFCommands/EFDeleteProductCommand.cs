using Application.Commands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFDeleteProductCommand : BaseEFCommand, IDeleteProductCommand
    {
        public EFDeleteProductCommand(OnlineShopContext context) : base(context)
        {
        }


        public void Execute(int request)
        {
            var product= Context.Products.Find(request);
            if (product == null)
            {
                throw new EntityNotFoundException("Product");
            }

            Context.Products.Remove(product);

            Context.SaveChanges();

        }
    }
}
