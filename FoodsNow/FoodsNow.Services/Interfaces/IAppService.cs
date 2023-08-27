using FoodsNow.Core.Dto;

namespace FoodsNow.Services.Interfaces
{
    public interface IAppService
    {
        Task<List<FranchiseDto>> GetClientFranchises(Guid clientId);
        Task<HomeDataDto> GetAppHomeData(Guid franchiseId);
        Task<ProductsDataDto> GetProducts(Guid categoryId); 
        Task<ProductDataDto> GetProductById(Guid productId); 
        Task<ProductsDataDto> GetProductsById(List<Guid> productIds); 
    }
}
