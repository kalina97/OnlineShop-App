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
    public class EFEditUserCommand : BaseEFCommand, IEditUserCommand
    {
        public EFEditUserCommand(OnlineShopContext context) : base(context)
        {
        }

        public void Execute(UserDto request)
        {
            var user = Context.Users.Find(request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException("User");
            }

            if (user.Username != request.Username)
            {
                if (Context.Users.Any(c => c.Username == request.Username))
                {
                    throw new EntityAlreadyExistsException("Username");
                }

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Username = request.Username;
                user.RoleId = request.RoleId;
                user.Password = request.Password;

                Context.SaveChanges();
            }

        }

    }
}
