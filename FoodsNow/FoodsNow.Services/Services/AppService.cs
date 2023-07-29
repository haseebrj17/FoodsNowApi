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
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public AppService(IFranchiseRepository franchiseRepository, IBannerRepository bannerRepository, IMapper mapper,
            IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _franchiseRepository = franchiseRepository;
            _bannerRepository = bannerRepository;
            _brandRepository = brandRepository;
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

                homeData.Brands = _mapper.Map<List<Brand>, List<BrandDto>>(_brandRepository.GetFranchiseBrands(franchise.Id));

            }

            return homeData;
        }
    }
}
