using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
            : base($"Actor with id: {actor.Id} - {actor.Identity}, tryed to execute {useCase.UseCaseName}")
        {

        }
    }
}
