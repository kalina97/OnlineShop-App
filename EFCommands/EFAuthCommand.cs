using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFAuthCommand : BaseEFCommand, IAuthCommand
    {
        public EFAuthCommand(OnlineShopContext context) : base(context)
        {
        }

        public AuthDto Execute(AuthDto request)
        {
            var user = Context.Users
                .Include(u => u.Role)
                .Where(u => u.Username == request.Username)
                .Where(u => u.Password == request.Password)
                .FirstOrDefault();


            if (user == null)
                throw new EntityNotFoundException("User");

            return new AuthDto
            {
                Id=user.Id,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Password = user.Password,
                Username = user.Username,
                RoleName = user.Role.RoleName,
                RoleId=user.Role.Id
            };
        }
    }
}
