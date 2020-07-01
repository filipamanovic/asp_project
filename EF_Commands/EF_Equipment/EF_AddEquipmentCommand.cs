using Application.Commands.Equipment;
using Application.Dto;
using Application.Exceptions;
using Domain;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Equipment
{
    public class EF_AddEquipmentCommand : EF_BaseEntity, IAddEquipmentCommand
    {
        public EF_AddEquipmentCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 31;
        public string UseCaseName => "CreateEquipmentUsingEF";

        public void Execute(EquipmentDto request)
        {
            if (Context.CarEquipments.Any(e => e.EquipmentName.ToLower() == request.EquipmentName.ToLower()))
                throw new EntityAlreadyExistException();

            Context.CarEquipments.Add(new CarEquipment 
            { 
                EquipmentName = request.EquipmentName 
            });

            Context.SaveChanges();
        }
    }
}
