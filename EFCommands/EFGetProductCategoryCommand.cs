using Application.Commands;
using Application.DTO;
using Application.Interfaces;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFGetProductCategoryCommand : BaseEFCommand, IGetProductCategoryCommand
    {
        public EFGetProductCategoryCommand(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<CategoryDto> Execute(ProductCategorySearch request)
        {
            var categories = Context.Categories.AsQueryable().
                Include(p => p.CategoryProducts).
                ThenInclude(pa => pa.Product);

            return categories.Select(a => new CategoryDto
            {
                Id = a.Id,
                Name=a.Name,
                Products = a.CategoryProducts.Select(x => new ProductCategoryDto
                {
                    Product = x.Product,
                    Category = x.Category,
                    ProductId = x.ProductId,
                    CategoryId = x.CategoryId

                }).ToList()



            }).ToList();



        }
    }
}
