using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands
{
    public abstract class EF_BaseEntity
    {
        protected asp_projectContext Context { get; }
        protected EF_BaseEntity(asp_projectContext context) => Context = context;
    }
}
