using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFGetRoleCommand : BaseEFCommand, IGetRoleCommand
    {
        public EFGetRoleCommand(OnlineShopContext context) : base(context)
        {
        }

        public RoleDto Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null)
                throw new EntityNotFoundException("Role");

            return new RoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName
            };

        }
    }
}
