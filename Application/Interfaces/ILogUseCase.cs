using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ILogUseCase
    {
        void Log(IUseCase useCase, IApplicationActor actor, object useCaseData);
    }
}
