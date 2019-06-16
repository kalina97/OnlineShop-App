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
    public class EFAddBrandCommand : BaseEFCommand, IAddBrandCommand
    {
        public EFAddBrandCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(BrandDto request)
        {

            if (Context.Brands.Any(b => b.BrandName == request.BrandName))
            {
                throw new EntityAlreadyExistsException("Brand name");
              
            }

            Context.Brands.Add(new Domain.Brand
            {
                BrandName=request.BrandName

            });

            Context.SaveChanges();

        }
    }
}
