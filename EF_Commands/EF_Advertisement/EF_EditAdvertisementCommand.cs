using Application.Commands.Advertisement;
using Application.Dto.AdvertisementDto;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_Advertisement
{
    public class EF_EditAdvertisementCommand : EF_BaseEntity, IEditAdvertisementCommand
    {
        public EF_EditAdvertisementCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 39;
        public string UseCaseName => "EditAdvertisementUsingEF";

        public void Execute(AdvertisementEdit request)
        {
            var advertisement = Context.Advertisements.Find(request.Id);

            if (advertisement == null)
                throw new EntityNotFoundException();
            if (advertisement.IsDeleted)
                throw new EntityAlreadyDeletedException();
            if (advertisement.AdName != request.AdName && request.AdName != null)
                if (Context.Advertisements.Any(a => a.AdName.ToLower() == request.AdName.ToLower()))
                    throw new EntityAlreadyExistException();

            if (request.AdName != null)
                advertisement.AdName = request.AdName;
            if (request.AdDesc != null)
                advertisement.AdDescription = request.AdDesc;
            if (request.Price.HasValue)
                advertisement.Price = (int)request.Price;
            if (request.KmValue.HasValue)
                advertisement.KmValue = (int)request.KmValue;
            if (request.EnginePower.HasValue)
                advertisement.EnginePower = (int)request.EnginePower;
            if (request.EngineVolume.HasValue)
                advertisement.EngineVolume = (int)request.EngineVolume;
            if (request.ProductionYear.HasValue)
                advertisement.ProductionYear = (int)request.ProductionYear;
            if (request.City != null)
                advertisement.City = request.City;

            Context.SaveChanges();
        }
    }
}
