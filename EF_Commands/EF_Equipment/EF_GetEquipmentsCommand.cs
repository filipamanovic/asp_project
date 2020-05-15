using Application.Commands.Equipment;
using Application.Dto;
using Application.Searches;
using Domain;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Equipment
{
    public class EF_GetEquipmentsCommand : EF_BaseEntity, IGetEquipmentsCommand
    {
        public EF_GetEquipmentsCommand(asp_projectContext context) : base(context)
        {
        }

        public IEnumerable<EquipmentDto> Execute(EquipmentSearch request)
        {
            var query = Context.CarEquipments.AsQueryable();

            if (request.Keyword != null)
                query = query.Where(e => e.EquipmentName.ToLower().Contains(request.Keyword.ToLower()));

            return query.Where(e => !e.IsDeleted).Select(e => new EquipmentDto
            {
                EquipmentName = e.EquipmentName
            });
        }
    }
}
