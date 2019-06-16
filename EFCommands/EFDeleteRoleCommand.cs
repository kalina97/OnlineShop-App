using Application.Commands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFDeleteRoleCommand : BaseEFCommand, IDeleteRoleCommand
    {
        public EFDeleteRoleCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var role = Context.Roles.Find(request);
            if (role == null)
            {
                throw new EntityNotFoundException("Role");
            }

            Context.Roles.Remove(role);

            Context.SaveChanges();

        }

    }
}
