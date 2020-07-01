using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ForeignKeyNotFoundException : Exception
    {
        public ForeignKeyNotFoundException(string msg) : base(msg + " foreinKey not found") {}
    }
}
