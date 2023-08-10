using FoodsNow.Core.Dto;

namespace FoodsNow.Services.Interfaces
{
    public interface IAppService
    {
        Task<List<FranchiseDto>> GetClientFranchises(Guid clientId);
        Task<HomeDataDto> GetAppHomeData(Guid franchiseId);
        Task<ProductDataDto> GetProducts(Guid categoryId); 
    }
}
