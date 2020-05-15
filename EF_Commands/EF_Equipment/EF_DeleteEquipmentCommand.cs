using Application.Commands.Equipment;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_Equipment
{
    public class EF_DeleteEquipmentCommand : EF_BaseEntity, IDeleteEquipmentCommand
    {
        public EF_DeleteEquipmentCommand(asp_projectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var equipment = Context.CarEquipments.Find(request);

            if (equipment == null)
                throw new EntityNotFoundException();
            if (equipment.IsDeleted)
                throw new EntityAlreadyDeletedException();

            equipment.IsDeleted = true;
            equipment.DeletedAt = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
