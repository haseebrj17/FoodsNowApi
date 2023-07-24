using FoodsNow.Core.Dto;
using FoodsNow.DbEntities.Repositories;
using FoodsNow.Services.Interfaces;

namespace FoodsNow.Services.Services
{
    public class AppService : IAppService
    {
        private readonly IFranchiseRepository _franchiseRepository;
        public AppService(IFranchiseRepository franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }
        public async Task<HomeDataDto> GetHomeData(decimal latitude, decimal longitude)
        {
            var homeData = new HomeDataDto();

            var franchise = await _franchiseRepository.GetFranchiseDetail(latitude, longitude);

            if (franchise != null)
            {
                homeData.FranchiseId = franchise.Id;
            }

            return homeData;
        }
    }
}
