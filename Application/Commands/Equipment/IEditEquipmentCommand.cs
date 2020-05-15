﻿using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Equipment
{
    public interface IEditEquipmentCommand : ICommand<EquipmentDto>
    {
    }
}
