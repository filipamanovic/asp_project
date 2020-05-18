using Application.Dto.AdvertisementDto;
using Application.Interfaces;
using Application.Responcses;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Advertisement
{
    public interface IGetAdvertisementsCommand : ICommand<AdvertisementSearch, PageResponse<AdvertisementShow>>
    {
    }
}
