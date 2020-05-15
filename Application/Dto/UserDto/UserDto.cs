using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto.UserDto
{
    public class UserDto
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z][a-z]{2,30}$",
         ErrorMessage = "User FirstName format is not allowed.")]
        [Required]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z][a-z]{2,30}$",
         ErrorMessage = "User LastName format is not allowed.")]
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
