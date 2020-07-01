using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserUseCase : BaseEntity
    {
        public int UseCaseId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
