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
    public class EFAddRoleCommand : BaseEFCommand, IAddRoleCommand
    {
        public EFAddRoleCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(RoleDto request)
        {

            if (Context.Roles.Any(r => r.RoleName == request.RoleName))
            {
                throw new EntityAlreadyExistsException("Role name");

            }


            Context.Roles.Add(new Domain.Role
            {
                RoleName=request.RoleName

            });

            Context.SaveChanges();

        }
    }
}
