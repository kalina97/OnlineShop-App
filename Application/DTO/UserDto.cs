using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class UserDto

    {
        public int Id { get; set; }
        [RegularExpression("^[A-Z][a-z]{2,15}$", ErrorMessage = "Invalid first name format.")]
        public string FirstName { get; set; }
        [RegularExpression("^[A-Z][a-z]{2,20}$", ErrorMessage = "Invalid last name format.")]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [RegularExpression("^([A-Za-z0-9]){8,}$", ErrorMessage = "Invalid password format.")]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
      

    }
}
