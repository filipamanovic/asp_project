using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface ICommand<TRequest, TResult> : IUseCase
    {
        TResult Execute(TRequest request);
    }

    public interface ICommand : IUseCase
    {
        void Execute();
    }

    public interface IUseCase
    {
        int Id { get; }
        string UseCaseName { get; }
    }
}
