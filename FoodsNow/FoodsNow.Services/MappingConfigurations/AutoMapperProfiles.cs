using AutoMapper;
using FoodsNow.Core;
using FoodsNow.Core.Dto;
using FoodsNow.Core.RequestModels;
using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FoodsNow.Services.MappingConfigurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            CreateMap<State, StateDto>();
            CreateMap<StateDto, State>();

            CreateMap<CityName, CityNameDto>();
            CreateMap<CityNameDto, CityName>();

            CreateMap<Franchise, FranchiseDto>();
            CreateMap<FranchiseDto, Franchise>();

            CreateMap<FranchiseTiming, FranchiseTimingDto>();
            CreateMap<FranchiseTimingDto, FranchiseTiming>();

            CreateMap<ServingTimings, ServingTimingsDto>();
            CreateMap<ServingTimingsDto, ServingTimings>();

            CreateMap<ServingTime, ServingTimeDto>();
            CreateMap<ServingTimeDto, ServingTime>();

            CreateMap<FranchiseHoliday, FranchiseHolidayDto>();
            CreateMap<FranchiseHolidayDto, FranchiseHoliday>();

            CreateMap<DishOfDay, DishOfDayDto>();
            CreateMap<DishOfDayDto, DishOfDay>();

            CreateMap<Discounts, DiscountsDto>();
            CreateMap<DiscountsDto, Discounts>();

            CreateMap<Banner, BannerDto>();
            CreateMap<BannerDto, Banner>();

            CreateMap<FranchiseSettingDto, FranchiseSetting>();
            CreateMap<FranchiseSetting, FranchiseSettingDto>();

            CreateMap<ServingDays, ServingDaysDto>();
            CreateMap<ServingDaysDto, ServingDays>();

            CreateMap<DishOfDay, DishOfDayDto>();
            CreateMap<DishOfDayDto, DishOfDay>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<SubCategoryDto, SubCategory>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductAllergy, ProductAllergyDto>();
            CreateMap<ProductAllergyDto, ProductAllergy>();

            CreateMap<ProductPrice, ProductPriceDto>();
            CreateMap<ProductPriceDto, ProductPrice>();

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryDto, ProductCategory>();

            CreateMap<ProductChoices, ProductChoicesDto>();
            CreateMap<ProductChoicesDto, ProductChoices>();

            CreateMap<ProductExtraDipping, ProductExtraDippingDto>();
            CreateMap<ProductExtraDippingDto, ProductExtraDipping>();

            CreateMap<ProductExtraDippingAllergy, ProductExtraDippingAllergyDto>();
            CreateMap<ProductExtraDippingAllergyDto, ProductExtraDippingAllergy>();

            CreateMap<ProductExtraDippingPrice, ProductExtraDippingPriceDto>();
            CreateMap<ProductExtraDippingPriceDto, ProductExtraDippingPrice>();

            CreateMap<ProductExtraTopping, ProductExtraToppingDto>();
            CreateMap<ProductExtraToppingDto, ProductExtraTopping>();

            CreateMap<ProductExtraToppingAllergy, ProductExtraToppingAllergyDto>();
            CreateMap<ProductExtraToppingAllergyDto, ProductExtraToppingAllergy>();

            CreateMap<ProductExtraToppingPrice, ProductExtraToppingPriceDto>();
            CreateMap<ProductExtraToppingPriceDto, ProductExtraToppingPrice>();

            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<CurrentAppUser, Customer>();
            CreateMap<Customer, CurrentAppUser>();

            CreateMap<CustomerAddresses, CustomerAddressDto>();
            CreateMap<CustomerAddressDto, CustomerAddresses>();

            CreateMap<CustomerPayment, CustomerPaymentDto>();
            CreateMap<CustomerPaymentDto, CustomerPayment>();

            CreateMap<CustomerPromo, CustomerPromoDto>();
            CreateMap<CustomerPromoDto, CustomerPromo>();

            CreateMap<CustomerDevice, CustomerDeviceDto>();
            CreateMap<CustomerDeviceDto, CustomerDevice>();

            CreateMap<CustomerPassword, CustomerPasswordDto>();
            CreateMap<CustomerPasswordDto, CustomerPassword>();

            CreateMap<CurrentAppUser, FranchiseUser>();
            CreateMap<FranchiseUser, CurrentAppUser>();

            CreateMap<CurrentAppUser, Client>();
            CreateMap<Client, CurrentAppUser>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<CustomerDetails, CustomerDetailsDto>();
            CreateMap<CustomerDetailsDto, CustomerDetails>();

            CreateMap<CustomerAddressDetail, CustomerAddressDetailDto>();
            CreateMap<CustomerAddressDetailDto, CustomerAddressDetail>();

            CreateMap<CustomerOrderPayment, CustomerOrderPaymentDto>();
            CreateMap<CustomerOrderPaymentDto, CustomerOrderPayment>();

            CreateMap<CustomerOrderPromo, CustomerOrderPromoDto>();
            CreateMap<CustomerOrderPromoDto, CustomerOrderPromo>();

            CreateMap<OrderProducts, OrderProductDto>();
            CreateMap<OrderProductDto, OrderProducts>();

            CreateMap<OrderedProductChoices, OrderedProductChoicesDto>();
            CreateMap<OrderedProductChoicesDto, OrderedProductChoices>();

            CreateMap<OrderedProductExtraDipping, OrderedProductExtraDippingDto>();
            CreateMap<OrderedProductExtraDippingDto, OrderedProductExtraDipping>();

            CreateMap<OrderedProductExtraTopping, OrderedProductExtraToppingDto>();
            CreateMap<OrderedProductExtraToppingDto, OrderedProductExtraTopping>();
        }

    }
}
