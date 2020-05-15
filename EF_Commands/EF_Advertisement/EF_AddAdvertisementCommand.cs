using Application.Commands.Advertisement;
using Application.Dto.AdvertisementDto;
using Application.Exceptions;
using Domain;
using EF_DataAccess;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Advertisement
{
    public class EF_AddAdvertisementCommand : EF_BaseEntity, IAddAdvertisementCommand
    {
        public EF_AddAdvertisementCommand(asp_projectContext context) : base(context)
        {
        }

        public void Execute(AdvertisementDto request)
        {
            if (Context.Advertisements.Any(a => a.AdName.ToLower() == request.AdName.ToLower()))
                throw new EntityAlreadyExistException();
            if (!Context.Models.Any(m => m.Id == request.ModelId))
                throw new ForeinKeyNotFoundException("Model");
            if (!Context.CarBodies.Any(cb => cb.Id == request.CarBodyId))
                throw new ForeinKeyNotFoundException("CarBody");
            if (!Context.Fuels.Any(f => f.Id == request.FuelId))
                throw new ForeinKeyNotFoundException("Fuel");
            if (!Context.Categories.Any(c => c.Id == request.CategoryId))
                throw new ForeinKeyNotFoundException("Category");
            if (!Context.Users.Any(u => u.Id == request.UserId))
                throw new ForeinKeyNotFoundException("User");

            List<CarEquipmentAd> carEquipment = new List<CarEquipmentAd>();
            if (request.CarEquipments != null) 
            {
                if (!request.CarEquipments.GroupBy(x => x).All(g => g.Count() == 1))
                    throw new DuplicateCarEquipmentException();
                foreach(var x in request.CarEquipments)
                {
                    if (!Context.CarEquipments.Any(ce => ce.Id == x))
                        throw new ForeinKeyNotFoundException("Car equipment");

                    carEquipment.Add(new CarEquipmentAd
                    {
                        CarEquipmentId = x
                    });
                }                            
            }

            Context.Advertisements.Add(new Advertisement
            {
                AdName = request.AdName,
                AdDescription = request.AdDesc,
                City = request.City,
                Price = request.Price,
                EnginePower = request.EnginePower,
                EngineVolume = request.EngineVolume,
                ProductionYear = request.ProductionYear,
                KmValue = request.KmValue,
                CarBodyId = request.CarBodyId,
                CategoryId = request.CategoryId,
                FuelId = request.FuelId,
                UserId = request.UserId,
                ModelId = request.ModelId,
                Images = request.ImagesInsert,
                AdCarEquipments = carEquipment
            });

            Context.SaveChanges();

        }
    }
}
