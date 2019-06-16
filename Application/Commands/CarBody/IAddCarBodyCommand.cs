using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CarBody
{
    public interface IAddCarBodyCommand : ICommand<CarBodyDto>
    {
    }
}
