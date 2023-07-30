using AutoMapper;
using FoodsNow.Core.Dto;
using FoodsNow.DbEntities.Models;

namespace FoodsNow.Services.MappingConfigurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Banner, BannerDto>();

            CreateMap<Category, CategoryDto>();
        }

    }
}
