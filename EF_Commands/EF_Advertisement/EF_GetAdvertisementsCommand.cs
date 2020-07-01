using Application.Commands.Advertisement;
using Application.Dto.AdvertisementDto;
using Application.Dto.UserDtoData;
using Application.Responcses;
using Application.Searches;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Advertisement
{
    public class EF_GetAdvertisementsCommand : EF_BaseEntity, IGetAdvertisementsCommand
    {
        public EF_GetAdvertisementsCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 37;
        public string UseCaseName => "GetAdvertisementsUsingEF";

        public PageResponse<AdvertisementShow> Execute(AdvertisementSearch request)
        {
            var query = Context.Advertisements.AsQueryable();

            if (request.Name != null)
                query = query.Where(a => a.AdName.ToLower().Contains(request.Name.ToLower()));
            if (request.City != null)
                query = query.Where(a => a.City.ToLower().Contains(request.City.ToLower()));
            if (request.MinPrice.HasValue)
                query = query.Where(a => a.Price >= request.MinPrice);
            if (request.MaxPrice.HasValue)
                query = query.Where(a => a.Price <= request.MaxPrice);
            if (request.KmValueMin.HasValue)
                query = query.Where(a => a.KmValue >= request.KmValueMin);
            if (request.KmValueMax.HasValue)
                query = query.Where(a => a.KmValue <= request.KmValueMax);
            if (request.EnginePowerMin.HasValue)
                query = query.Where(a => a.EnginePower >= request.EnginePowerMin);
            if (request.EnginePowerMax.HasValue)
                query = query.Where(a => a.EnginePower <= request.EnginePowerMax);
            if (request.EngiveVolumeMin.HasValue)
                query = query.Where(a => a.EngineVolume >= request.EngiveVolumeMin);
            if (request.EngineVolumeMax.HasValue)
                query = query.Where(a => a.EngineVolume <= request.EngineVolumeMax);
            if (request.ProductionYearMin.HasValue)
                query = query.Where(a => a.ProductionYear >= request.ProductionYearMin);
            if (request.ProductionYearMax.HasValue)
                query = query.Where(a => a.ProductionYear <= request.ProductionYearMax);
            if (request.ModelId.HasValue)
                query = query.Where(a => a.ModelId == request.ModelId);
            if (request.CarBodyId.HasValue)
                query = query.Where(a => a.CarBodyId == request.CarBodyId);  
            if (request.FuelId.HasValue)
                query = query.Where(a => a.FuelId == request.FuelId);
            if (request.CategoryId.HasValue)
                query = query.Where(a => a.CategoryId == request.CategoryId);
            if (request.BrandId.HasValue)
                query = query.Where(a => a.Model.BrandId == request.BrandId);

            query = query.Where(a => !a.IsDeleted);

            var totalCount = query.Count();

            query = query.Skip((request.CurrentPage - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PageResponse<AdvertisementShow>
            {
                CurrentPage = request.CurrentPage,
                PageCount = pagesCount,
                TotalCount = totalCount,
                ItemsPerPage = request.PerPage, 
                Data = query.Select(a => new AdvertisementShow
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
                })
            };
        }
    }
}
