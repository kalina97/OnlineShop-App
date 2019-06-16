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
    public class EFGetProductCommand : BaseEFCommand, IGetProductCommand
    {
        public EFGetProductCommand(OnlineShopContext context) : base(context)
        {
        }

        public ProductDto Execute(int request)
        {
            var product = Context.Products.Find(request);

            if (product == null)
                throw new EntityNotFoundException("Product");

            return new ProductDto 
            {
                Id = product.Id,
                Name=product.Name,
                Description=product.Description,
                ImageSrc=product.ImageSrc,
                Price=product.Price,
                AvailableCount=product.AvailableCount,
                BrandId=product.BrandId
               



            };

        }
    }
}
