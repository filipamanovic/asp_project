using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class DuplicateCarEquipmentException : Exception
    {
        public readonly string msg = "Duplicate CarEquipment";
    }
}
