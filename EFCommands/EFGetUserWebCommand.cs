using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFGetUserWebCommand : BaseEFCommand, IGetUserWebCommand
    {
        public EFGetUserWebCommand(OnlineShopContext context) : base(context)
        {
        }

        public UserWebDto Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null)
                throw new EntityNotFoundException("User");

            return new UserWebDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = "Hidden For Security Reasons"
            };

        }
    }
}
