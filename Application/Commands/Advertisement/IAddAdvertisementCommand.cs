using Application.Dto.AdvertisementDto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Advertisement
{
    public interface IAddAdvertisementCommand : ICommand<AdvertisementDto>
    {
    }
}
