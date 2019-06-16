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
    public class EFGetUsersWebCommand : BaseEFCommand, IGetUsersWebCommand
    {
        public EFGetUsersWebCommand(OnlineShopContext context) : base(context)
        {
        }

        public IEnumerable<UserWebDto> Execute(UserWebSearch request)
        {
            var query = Context.Users.AsQueryable();

            if (request.FirstName != null)
            {
                query = query.Where(c => c.FirstName
                .ToLower()
                .Contains(request.FirstName.ToLower()));
            }


            if (request.LastName != null)
            {
                query = query.Where(c => c.LastName
                .ToLower()
                .Contains(request.LastName.ToLower()));
            }



            if (request.Username != null)
            {
                query = query.Where(c => c.Username
                .ToLower()
                .Contains(request.Username.ToLower()));
            }

            return query.Select(b => new UserWebDto
            {
                Id = b.Id,
                FirstName=b.FirstName,
                LastName=b.LastName,
                Username=b.Username,
                Password="Hidden For Security Reasons",
                Role=b.Role
                
            });
        }

    }
}
