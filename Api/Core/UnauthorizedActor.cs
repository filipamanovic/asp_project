using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Unauthorized";

        public IEnumerable<int> AllowedUseCases => new List<int> { 26, 41 };
    }
}
