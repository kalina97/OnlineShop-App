using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Users
{
    public class UserIndexViewModel
    {
        public IEnumerable<UserDto> Users { get; set; }
        public IEnumerable<RoleDto> Roles { get; set; }


    }
}
