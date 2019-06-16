using Application.Dto;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Brand
{
    public interface IGetBrandsCommand : ICommand<BrandSearch, IEnumerable<BrandDto>>
    {
    }
}
