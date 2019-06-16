using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class RoleDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This is Required field")]
        public string RoleName { get; set; }
    }
}
