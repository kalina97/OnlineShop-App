using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class UserSearch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;

    }
}
