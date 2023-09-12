﻿using AutoMapper;
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

            CreateMap<CustomerDto, Customer>();

            CreateMap<Customer, CustomerDto>();
            
            CreateMap<CustomerAddress, CustomerAddressDto>();

            CreateMap<CustomerAddressDto, CustomerAddress>();

            CreateMap<OrderProductExtraToppingDto, OrderProductExtraTopping>();

            CreateMap<OrderProductExtraTopping, OrderProductExtraToppingDto>();

            CreateMap<OrderProductExtraTopping, OrderProductExtraToppingDto>();

            CreateMap<OrderProductExtraToppingDto, OrderProductExtraTopping>();

            CreateMap<OrderProductDto, OrderProduct>();

            CreateMap<OrderProduct, OrderProductDto>();

            CreateMap<OrderDto, Order>();

            CreateMap<Order, OrderDto>();

            CreateMap<OrderProductExtraDippingDto, OrderProductExtraDipping>();

            CreateMap<OrderProductExtraDipping, OrderProductExtraDippingDto>();

            CreateMap<OrderProductExtraToppingDto, OrderProductExtraTopping>();

            CreateMap<OrderProductExtraTopping, OrderProductExtraToppingDto>();

        }

    }
}
