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
    public class EFGetBrandsCommand : BaseEFCommand, IGetBrandsCommand
    {
        public EFGetBrandsCommand(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<BrandDto> Execute(BrandSearch request)
        {
            var query = Context.Brands.AsQueryable();

            if (request.BrandName != null)
            {
                query = query.Where(b => b.BrandName
                .ToLower()
                .Contains(request.BrandName.ToLower()));
            }

            return query.Select(b => new BrandDto
            {
               Id=b.Id,
               BrandName=b.BrandName
            });
        }

    }
}
