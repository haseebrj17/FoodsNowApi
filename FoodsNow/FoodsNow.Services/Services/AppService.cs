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

                homeData.Categories = _mapper.Map<List<Category>, List<CategoryDto>>(_categoryRepository.GetCategories(franchiseId));
            }

            return homeData;
        }

        public async Task<ProductsDataDto> GetProducts(Guid categoryId)
        {
            var categories = _categoryRepository.GetChildCategories(categoryId);

            var categoriesIds = categories.Select(c => c.Id).ToList();

            categoriesIds.Add(categoryId);

            var productsData = new ProductsDataDto
            {
                Categories = _mapper.Map<List<Category>, List<CategoryDto>>(categories),
                Products = _mapper.Map<List<Product>, List<ProductDto>>(await _productRepository.GetProductsByCategoryIds(categoriesIds)),
                ProductExtraDippings = _mapper.Map<List<ProductExtraDipping>, List<ProductExtraDippingDto>>(await _productExtraDippingRepository.GetProductExtraDippings()),
                ProductExtraTroppings = _mapper.Map<List<ProductExtraTopping>, List<ProductExtraToppingDto>>(await _productExtraToppingRepository.GetProductExtraToppings())
            };

            return productsData;
        }

        public async Task<ProductDataDto> GetProductById(Guid productId)
        {
            var productData = new ProductDataDto
            {
                Product = _mapper.Map<Product, ProductDto>(await _productRepository.GetProductById(productId))
            };

            if (productData.Product.showExtraDipping)
            {
                productData.ProductExtraDippings =
                    _mapper.Map<List<ProductExtraDipping>, List<ProductExtraDippingDto>>(await _productExtraDippingRepository.GetProductExtraDippings());
            }

            if (productData.Product.showExtraDipping)
            {
                productData.ProductExtraTroppings =
                    _mapper.Map<List<ProductExtraTopping>, List<ProductExtraToppingDto>>(await _productExtraToppingRepository.GetProductExtraToppings());
            }

            return productData;
        }

        public async Task<ProductsDataDto> GetProductsById(List<Guid> productIds)
        {
            var productsData = new ProductsDataDto
            {
                Products = _mapper.Map<List<Product>, List<ProductDto>>(await _productRepository.GetProductsById(productIds)),
                ProductExtraDippings = _mapper.Map<List<ProductExtraDipping>, List<ProductExtraDippingDto>>(await _productExtraDippingRepository.GetProductExtraDippings()),
                ProductExtraTroppings = _mapper.Map<List<ProductExtraTopping>, List<ProductExtraToppingDto>>(await _productExtraToppingRepository.GetProductExtraToppings())
            };

            return productsData;
        }
    }
}
