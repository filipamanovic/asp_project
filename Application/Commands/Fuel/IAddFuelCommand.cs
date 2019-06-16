using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Fuel
{
    public interface IAddFuelCommand : ICommand<FuelDto>
    {
    }
}
