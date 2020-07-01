﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        public ICollection<UserUseCase> UserUseCases { get; set; }
    }
}
