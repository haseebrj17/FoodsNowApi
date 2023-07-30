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
        private readonly IBannerRepository _bannerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public AppService(IFranchiseRepository franchiseRepository, IBannerRepository bannerRepository, IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _franchiseRepository = franchiseRepository;
            _bannerRepository = bannerRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<HomeDataDto> GetAppHomeData(decimal latitude, decimal longitude)
        {
            var homeData = new HomeDataDto();

            var franchise = await _franchiseRepository.GetFranchiseDetail(latitude, longitude);

            if (franchise != null)
            {
                homeData.FranchiseId = franchise.Id;

                homeData.ClientId = franchise.ClientId;

                homeData.Banners = _mapper.Map<List<Banner>, List<BannerDto>>(_bannerRepository.GetFranchiseBanners(franchise.Id));

                homeData.Categories = _mapper.Map<List<Category>, List<CategoryDto>>(_categoryRepository.GetFranchiseBrands(franchise.Id));

            }

            return homeData;
        }
    }
}
