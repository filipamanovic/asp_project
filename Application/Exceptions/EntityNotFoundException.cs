﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public readonly string msg = "EntityNotFound";
    }
}
