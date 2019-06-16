using Application.Commands;
using Application.DTO;
using Application.Responses;
using Application.Searches;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFGetUsersCommand : BaseEFCommand, IGetUsersCommand
    {
        public EFGetUsersCommand(OnlineShopContext context) : base(context)
        {
        }

        public PagedResponse<UserDto> Execute(UserSearch request)
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

            //paginacija za korisnike
            var totalCount = query.Count();


            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);




            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedResponse<UserDto>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = query.Select(p => new UserDto
                {
                    Id = p.Id,
                    FirstName=p.FirstName,
                    LastName=p.LastName,
                    Username=p.Username,
                    RoleId=p.RoleId,
                    Password="Hidden For Security Reasons"
                })
            };

            return response;




            /*return query.Select(b => new UserDto
            {
                Id = b.Id,
               FirstName=b.FirstName,
               LastName=b.LastName,
               Username=b.Username,
               RoleId=b.RoleId
              
            });
            */
        }
    }
}
