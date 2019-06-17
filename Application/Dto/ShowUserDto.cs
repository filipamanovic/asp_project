using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class ShowUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IEnumerable<Advertisement> Advertisements { get; set; }
    }
}
