using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ForeinKeyNotFoundException : Exception
    {
        public ForeinKeyNotFoundException(string msg) : base(msg + " foreinKey not found") {}
    }
}
