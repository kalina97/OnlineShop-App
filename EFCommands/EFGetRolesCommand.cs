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
    public class EFGetRolesCommand : BaseEFCommand, IGetRolesCommand
    {
        public EFGetRolesCommand(OnlineShopContext context) : base(context)
        {
        }


        public IEnumerable<RoleDto> Execute(RoleSearch request)
        {
            var query = Context.Roles.AsQueryable();

            if (request.RoleName != null)
            {
                query = query.Where(c => c.RoleName
                .ToLower()
                .Contains(request.RoleName.ToLower()));
            }

            return query.Select(b => new RoleDto
            {
                Id = b.Id,
                RoleName=b.RoleName
            });
        }
    }
}
