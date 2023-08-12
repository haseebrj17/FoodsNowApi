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

            CreateMap<Franchise, FranchiseDto>();

            CreateMap<Product, ProductDto>();

            CreateMap<ProductPrice, ProductPriceDto>();

            CreateMap<ProductExtraDipping, ProductExtraDippingDto>();

            CreateMap<ProductExtraTopping, ProductExtraToppingDto>();

            CreateMap<ProductExtraToppingPrice, ProductExtraToppingPriceDto>();

            CreateMap<ProductExtraDippingPrice, ProductExtraDippingPriceDto>();

            CreateMap<Allergy, AllergyDto>();

            CreateMap<ProductAllergy, ProductAllergyDto>();

            CreateMap<ProductExtraDippingAllergy, ProductAllergyDto>();

            CreateMap<ProductExtraToppingAllergy, ProductAllergyDto>();
        }

    }
}
