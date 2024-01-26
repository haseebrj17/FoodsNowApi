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

                homeData.Banners = _mapper.Map<List<Banner>, List<BannerDto>>(await _bannerRepository.GetFranchiseBanners(franchiseId));

                homeData.Brands = _mapper.Map<List<Category>, List<CategoryDto>>(_categoryRepository.GetFranchiseBrands(franchiseId));

                homeData.Categories = _mapper.Map<List<Category>, List<CategoryDto>>(_categoryRepository.GetFranchiseCategories(franchiseId));
            }

            return homeData;
        }

        public async Task<ProductsDataDto> GetProducts(Guid categoryId, bool AddSides)
        {
            var categories = _categoryRepository.GetChildCategories(categoryId).ToList();
            var categoriesIds = categories.Select(c => c.Id).ToList();
            categoriesIds.Add(categoryId);

            List<SubCategory> sidesCategories = new List<SubCategory>();

            var brandIds = new List<Guid> { categoryId };

            if (AddSides)
            {
                var sides = _categoryRepository.GetCategoryByName("Sides");
                if (sides != null)
                {
                    sidesCategories = _categoryRepository.GetChildCategories(sides.Id);
                    var sidesCategoriesIds = sidesCategories.Select(c => c.Id).ToList();
                    sidesCategoriesIds = sidesCategoriesIds.Except(categoriesIds).ToList();
                    categoriesIds.AddRange(sidesCategoriesIds);
                    brandIds.Add(sides.Id);
                }
            }

            var productsData = new ProductsDataDto
            {
                Categories = _mapper.Map<List<SubCategory>, List<SubCategoryDto>>(categories),
                Products = _mapper.Map<List<Product>, List<ProductDto>>(await _productRepository.GetProductsByCategoryIds(brandIds)),
            };

            if (AddSides && sidesCategories.Any())
            {
                productsData.Categories.AddRange(_mapper.Map<List<SubCategory>, List<SubCategoryDto>>(sidesCategories));
            }

            return productsData;
        }

        public async Task<ProductsDataDto> GetProductById(Guid productId)
        {
            var product = await _productRepository.GetProductById(productId);
            var productDto = _mapper.Map<ProductDto>(product);

            var productsData = new ProductsDataDto
            {
                Products = new List<ProductDto> { productDto }
            };

            return productsData;
        }

        public async Task<ProductsDataDto> GetProductsById(List<Guid> productIds)
        {
            var productsData = new ProductsDataDto
            {
                Products = _mapper.Map<List<Product>, List<ProductDto>>(await _productRepository.GetProductsById(productIds)),
            };

            return productsData;
        }
    }
}
