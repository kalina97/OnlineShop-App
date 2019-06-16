using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Logging
{
    public class LoggedUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public bool IsLogged { get; set; }
    }
}
