using Application.Commands.Advertisement;
using Application.Dto.AdvertisementDto;
using Application.Dto.UserDtoData;
using Application.Exceptions;
using EF_DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Advertisement
{
    public class EF_GetAdvertisementCommand : EF_BaseEntity, IGetAdvertisementCommand
    {
        public EF_GetAdvertisementCommand(asp_projectContext context) : base(context)
        {
        }

        public AdvertisementShow Execute(int request)
        {
            var advertisement = Context.Advertisements.Find(request);

            if (advertisement == null)
                throw new EntityNotFoundException();
            if (advertisement.IsDeleted)
                throw new EntityAlreadyDeletedException();

            var query = Context.Advertisements.AsQueryable();

            return query.Where(a => a.Id == request).Select(a => new AdvertisementShow
            {
                AdName = a.AdName,
                AdDesc = a.AdDescription,
                City = a.City,
                EnginePower = a.EnginePower,
                EngineVolume = a.EngineVolume,
                KmValue = a.KmValue,
                Price = a.Price,
                ProductionYear = a.ProductionYear,
                CarBodyName = a.CarBody.Name,
                CategoryName = a.Category.Name,
                FuelName = a.Fuel.Name,
                ModelName = a.Model.Name,
                BrandName = a.Model.Brand.Name,
                ImagesData = a.Images.Select(i => i.Src),
                UserInfo = new UserDto 
                { 
                    FirstName = a.User.FirstName, 
                    LastName = a.User.LastName, 
                    Email = a.User.Email,
                    PhoneNumber = a.User.PhoneNumber
                },
                CarEquipmentNames = a.AdCarEquipments.Select(e => e.CarEquipment.EquipmentName)
            }).First();
        }
    }
}
