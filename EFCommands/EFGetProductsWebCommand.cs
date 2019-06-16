using Application.Commands;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFGetProductsWebCommand : BaseEFCommand, IGetProductsWebCommand
    {
        public EFGetProductsWebCommand(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<ProductWebDto> Execute(ProductWebSearch request)
        {
            var query = Context.Products.AsQueryable();

            if (request.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= request.MinPrice);
            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= request.MaxPrice);
            }

            if (request.ProductName != null)
            {
                var keyword = request.ProductName.ToLower();

                query = query.Where(p => p.Name.ToLower().Contains(keyword));
            }


            return query.Select(p => new ProductWebDto
            {
                Id = p.Id,
                AvailableCount = p.AvailableCount,
                Name = p.Name,
                Price = p.Price,
                BrandId = p.BrandId,
                Description = p.Description,
                CategoryNames = p.ProductCategories.Select(pc => pc.Category.Name),
                ImageSrc = p.ImageSrc
            });
        }
    }
}
