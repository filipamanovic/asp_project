using Application.Commands.Equipment;
using Application.Dto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Equipment
{
    public class EF_EditEquipmentCommand : EF_BaseEntity, IEditEquipmentCommand
    {
        public EF_EditEquipmentCommand(asp_projectContext context) : base(context)
        {
        }

        public void Execute(EquipmentDto request)
        {
            var equipment = Context.CarEquipments.Find(request.Id);

            if (equipment == null)
                throw new EntityNotFoundException();
            if (equipment.IsDeleted)
                throw new EntityAlreadyDeletedException();
            if (equipment.EquipmentName != request.EquipmentName)
                if (Context.CarEquipments.Any(e => e.EquipmentName.ToLower() == request.EquipmentName.ToLower()))
                    throw new EntityAlreadyExistException();

            equipment.EquipmentName = request.EquipmentName;
            Context.SaveChanges();

        }
    }
}
