using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityAlreadyExistException : Exception
    {
        public readonly string msg = "EntityAlreadyExist";
    }
}
