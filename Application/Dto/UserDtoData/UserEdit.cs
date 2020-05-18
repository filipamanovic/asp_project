﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto.UserDtoData
{
    public class UserEdit
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z][a-z]{2,30}$",
         ErrorMessage = "User FirstName format is not allowed.")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z][a-z]{2,30}$",
         ErrorMessage = "User LastName format is not allowed.")]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}