using Application.Dto;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Model
{
    public interface IGetModelsCommand : ICommand<ModelSearch, IEnumerable<ModelDto>>
    {
    }
}
