using Application.Exceptions;
using Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Helpers
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor _actor;
        private readonly ILogUseCase _logUseCase;
        
        public UseCaseExecutor(IApplicationActor actor, ILogUseCase useCase)
        {
            _actor = actor;
            _logUseCase = useCase;
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            _logUseCase.Log(command, _actor, request);
            //Console.WriteLine($"{DateTime.Now}: {_actor.Identity}, is trying to execute {command.UseCaseName}, using data " +
            //    $"{JsonConvert.SerializeObject(request)}");
            if (!_actor.AllowedUseCases.Contains(command.Id))
                throw new UnauthorizedUseCaseException(command, _actor); //Status code 401 || 403
            command.Execute(request);
        }

        public TResponse ExecuteCommand<TRequest, TResponse>(ICommand<TRequest, TResponse> command, TRequest request)
        {
            _logUseCase.Log(command, _actor, request);
            if (!_actor.AllowedUseCases.Contains(command.Id))
                throw new UnauthorizedUseCaseException(command, _actor); //Status code 401 || 403
            return command.Execute(request);
        }
        public void ExecuteCommand(ICommand command)
        {
            _logUseCase.Log(command, _actor, null);
            if (!_actor.AllowedUseCases.Contains(command.Id))
                throw new UnauthorizedUseCaseException(command, _actor); //Status code 401 || 403
            command.Execute();
        }
    }
}
