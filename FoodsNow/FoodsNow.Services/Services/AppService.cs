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
        private readonly IMapper _mapper;

        public AppService(IFranchiseRepository franchiseRepository, IBannerRepository bannerRepository, IMapper mapper,
            ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _franchiseRepository = franchiseRepository;
            _bannerRepository = bannerRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
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

        public async Task<List<ProductDto>> GetProducts(Guid categoryId)
        {
            return _mapper.Map<List<Product>, List<ProductDto>>(await _productRepository.GetProductsByCategoryId(categoryId));
        }
    }
}
