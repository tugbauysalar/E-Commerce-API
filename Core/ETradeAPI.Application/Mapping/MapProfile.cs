using AutoMapper;
using ETradeAPI.Application.DTOs;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //entity ve dto'ların eşleşmesi için mapping yapıldı.
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();   
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
