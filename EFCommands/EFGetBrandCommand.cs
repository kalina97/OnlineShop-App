using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFGetBrandCommand : BaseEFCommand, IGetBrandCommand
    {
        public EFGetBrandCommand(OnlineShopContext context) : base(context)
        {
        }

        public BrandDto Execute(int request)
        {
            var brand = Context.Brands.Find(request);

            if (brand == null)
                throw new EntityNotFoundException("Brand");

            return new BrandDto
            {
                Id = brand.Id,
                BrandName = brand.BrandName
            };

        }

    }
}
