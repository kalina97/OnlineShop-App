using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFGetProductWebCommand : BaseEFCommand, IGetProductWebCommand
    {
        public EFGetProductWebCommand(OnlineShopContext context) : base(context)
        {
        }

        public ProductWebDto Execute(int request)
        {
            var product = Context.Products.Find(request);

            if (product == null)
                throw new EntityNotFoundException("Product");

            return new ProductWebDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageSrc = product.ImageSrc,
                Price = product.Price,
                AvailableCount = product.AvailableCount,
                BrandId = product.BrandId



            };

        }
    }
}
