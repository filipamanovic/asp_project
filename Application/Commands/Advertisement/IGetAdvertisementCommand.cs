using Application.Dto.AdvertisementDto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Advertisement
{
    public interface IGetAdvertisementCommand : ICommand<int, AdvertisementShow>
    {
    }
}
