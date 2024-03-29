﻿using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class AuthDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
