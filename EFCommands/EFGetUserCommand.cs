using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFGetUserCommand : BaseEFCommand, IGetUserCommand
    {
        public EFGetUserCommand(OnlineShopContext context) : base(context)
        {
        }

        public UserDto Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null)
                throw new EntityNotFoundException("User");

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName=user.LastName,
                Username=user.Username,
                RoleId=user.RoleId,
                Password = "Hidden For Security Reasons"
            };

        }
    }
}
