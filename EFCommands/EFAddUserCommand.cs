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
    public class EFAddUserCommand : BaseEFCommand, IAddUserCommand
    {
        public EFAddUserCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(UserDto request)
        {

            if (Context.Users.Any(u => u.Username == request.Username))
            {
                throw new EntityAlreadyExistsException("Username");

            }

            if (!Context.Users.Any(u => u.RoleId == request.RoleId))
            {
                throw new EntityNotFoundException("Role");

            }



            Context.Users.Add(new Domain.User
            {
               FirstName=request.FirstName,
               LastName=request.LastName,
               Username=request.Username,
               RoleId=request.RoleId,
               Password=request.Password
               


            });

            Context.SaveChanges();

        }
    }
}
