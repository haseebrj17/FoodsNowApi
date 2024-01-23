using FoodsNow.Core.Dto;
using FoodsNow.Core.RequestModels;
using FoodsNow.Core.ResponseModels;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Services.Interfaces
{
    public interface IFranchiseService
    {
        Task<LoginResponse> UserLogin(LoginRequestModel customer);
        Task<List<OrderDto>> GetAllFranchiseOrders(Guid franchiseId);
        Task<List<OrderDetailDto>> GetCustomerOrders(Guid customerId);
        Task<OrderDto> GetOrderDetail(Guid orderId, Guid franchiseId);
        Task<bool> UpdateOrderStatus(Guid orderId, OrderStatus orderStatus,Guid loggedInUserId);
        Task<bool> UpdateDishStatus(Guid Id, Status status,Guid loggedInUserId);
        Task<bool> UpdateBrandStatus(Guid Id, Status status,Guid loggedInUserId);
        Task<bool> UpdateFranchiseStatus(Guid Id, Status status,Guid loggedInUserId);
    }
}
