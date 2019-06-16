using Application.Commands;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFGetCategoriesCommand : BaseEFCommand, IGetCategoriesCommand
    {
        public EFGetCategoriesCommand(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<CategoryDto> Execute(CategorySearch request)
        {
            var query = Context.Categories.AsQueryable();

            if (request.Keyword != null)
            {
                query = query.Where(b => b.Name
                .ToLower()
                .Contains(request.Keyword.ToLower()));
            }

            return query.Select(b => new CategoryDto
            {
                Id = b.Id,
                Name = b.Name,
               Products=b.CategoryProducts.Select(x=>new ProductCategoryDto
                {
                    Product=x.Product,
                    Category=x.Category,
                    ProductId=x.ProductId,
                    CategoryId=x.CategoryId

                }).ToList()
            });
        }
    }
}
