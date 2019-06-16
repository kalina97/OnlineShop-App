using Application.Commands;
using Application.DTO;
using Application.Responses;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFGetProductsCommand : BaseEFCommand, IGetProductsCommand
    {
        public EFGetProductsCommand(OnlineShopContext context) : base(context)
        {
        }

        public PagedResponse<ProductDto> Execute(ProductSearch request)
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


            if (request.CategoryId != null)
            {
                query = query.Where(p => p.ProductCategories.Any(pc => pc.CategoryId == request.CategoryId));
            }



            var totalCount = query.Count();


            query = query
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category).Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);




            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedResponse<ProductDto>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = query.Select(p => new ProductDto
                {
                    Id = p.Id,
                    AvailableCount = p.AvailableCount,
                    Name = p.Name,
                    Price = p.Price,
                    BrandId=p.BrandId,
                    Description=p.Description,
                    CategoryNames = p.ProductCategories.Select(pc => pc.Category.Name),
                    ImageSrc = p.ImageSrc
                })
            };

            return response;



        }
    }
}
