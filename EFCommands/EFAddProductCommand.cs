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
    public class EFAddProductCommand : BaseEFCommand, IAddProductCommand
    {
        public EFAddProductCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(ProductDto request)
        {

            if (Context.Products.Any(p => p.Name == request.Name))
            {
                throw new EntityAlreadyExistsException("Product name");

            }

            if (!Context.Products.Any(p => p.BrandId == request.BrandId))
            {
                throw new EntityNotFoundException("Brand");

            }



            Context.Products.Add(new Domain.Product
            {
                Name = request.Name,
                BrandId=request.BrandId,
                Description=request.Description,
                Price=request.Price,
                AvailableCount=request.AvailableCount,
                ImageSrc=request.ImageSrc


            });

            Context.SaveChanges();

        }
    }
}
