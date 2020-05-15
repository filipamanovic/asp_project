using Application.Commands.Equipment;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_Equipment
{
    public class EF_GetEquipmentCommand : EF_BaseEntity, IGetEquipmentCommand
    {
        public EF_GetEquipmentCommand(asp_projectContext context) : base(context)
        {
        }

        public EquipmentDto Execute(int request)
        {
            var equipment = Context.CarEquipments.Find(request);

            if (equipment == null)
                throw new EntityNotFoundException();
            if (equipment.IsDeleted)
                throw new EntityAlreadyDeletedException();

            return new EquipmentDto
            {
                EquipmentName = equipment.EquipmentName
            };
        }
    }
}
