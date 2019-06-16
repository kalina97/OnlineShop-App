using Application.Commands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFDeleteBrandCommand : BaseEFCommand, IDeleteBrandCommand
    {
        public EFDeleteBrandCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var brand = Context.Brands.Find(request);

            if (brand == null)
            {
                throw new EntityNotFoundException("Brand");
            }

            Context.Brands.Remove(brand);

            Context.SaveChanges();
        }

    }
}
