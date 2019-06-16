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
    public class EFEditProductWebCommand : BaseEFCommand, IEditProductWebCommand
    {
        public EFEditProductWebCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(ProductWebDto request)
        {
            var product = Context.Products.Find(request.Id);

            if (product == null)
            {
                throw new EntityNotFoundException("Product");
            }

            if (!Context.Products.Any(p => p.BrandId == request.BrandId))
            {
                throw new EntityNotFoundException("Product brand");
            }

            if (product.Name != request.Name)
            {
                if (Context.Products.Any(p => p.Name == request.Name))
                {
                    throw new EntityAlreadyExistsException("Product name");
                }

                product.Name = request.Name;
                product.Description = request.Description;
                product.AvailableCount = request.AvailableCount;
                product.BrandId = request.BrandId;
                product.ImageSrc = request.ImageSrc;
                product.Price = request.Price;

                Context.SaveChanges();
            }

        }
    }
}
