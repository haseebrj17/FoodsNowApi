using AutoMapper;
using FoodsNow.Core.Dto;
using FoodsNow.DbEntities.Models;
using FoodsNow.DbEntities.Repositories;
using FoodsNow.Services.Interfaces;

namespace FoodsNow.Services.Services
{
    public class AppService : IAppService
    {
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBannerRepository _bannerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductExtraToppingRepository _productExtraToppingRepository;
        private readonly IProductExtraDippingRepository _productExtraDippingRepository;

        private readonly IMapper _mapper;

        public AppService(IFranchiseRepository franchiseRepository, IBannerRepository bannerRepository, IMapper mapper,
            ICategoryRepository categoryRepository, IProductRepository productRepository, IProductExtraToppingRepository productExtraToppingRepository, IProductExtraDippingRepository productExtraDippingRepository)
        {
            _mapper = mapper;
            _franchiseRepository = franchiseRepository;
            _bannerRepository = bannerRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productExtraToppingRepository = productExtraToppingRepository;
            _productExtraDippingRepository = productExtraDippingRepository;
        }
        public async Task<List<FranchiseDto>> GetClientFranchises(Guid clientId)
        {
            return _mapper.Map<List<Franchise>, List<FranchiseDto>>(await _franchiseRepository.GetClientFranchises(clientId));
        }

        public async Task<HomeDataDto> GetAppHomeData(Guid franchiseId)
        {
            var homeData = new HomeDataDto();

            var franchise = await _franchiseRepository.GetClientFranchises(franchiseId);

            if (franchise != null)
            {
                homeData.FranchiseId = franchiseId;

                homeData.Banners = _mapper.Map<List<Banner>, List<BannerDto>>(_bannerRepository.GetFranchiseBanners(franchiseId));

                homeData.Brands = _mapper.Map<List<Category>, List<CategoryDto>>(_categoryRepository.GetFranchiseBrands(franchiseId));
            }

            return homeData;
        }

        public async Task<ProductDataDto> GetProducts(Guid categoryId)
        {
            var productsData = new ProductDataDto
            {
                Products = _mapper.Map<List<Product>, List<ProductDto>>(await _productRepository.GetProductsByCategoryId(categoryId)),
                ProductExtraDippings = _mapper.Map<List<ProductExtraDipping>, List<ProductExtraDippingDto>>(await _productExtraDippingRepository.GetProductExtraDippings()),
                ProductExtraTroppings = _mapper.Map<List<ProductExtraTopping>, List<ProductExtraToppingDto>>(await _productExtraToppingRepository.GetProductExtraToppings())
            };

            return productsData;
        }
    }
}
