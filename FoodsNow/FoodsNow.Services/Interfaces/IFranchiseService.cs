using FoodsNow.Core.Dto;
using FoodsNow.Core.RequestModels;
using FoodsNow.Core.ResponseModels;

namespace FoodsNow.Services.Interfaces
{
    public interface IFranchiseService
    {
        Task<LoginResponse> UserLogin(LoginRequestModel customer);
        Task<List<OrderDto>> GetAllOrders(Guid franchiseId);
        Task<OrderDto> GetOrderDetail(Guid orderId);
    }
}
