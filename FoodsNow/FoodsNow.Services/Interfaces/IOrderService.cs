using FoodsNow.Core.Dto;

namespace FoodsNow.Services.Interfaces
{
    public interface IOrderService
    {
       public Task<Guid?> PlaceOrder(OrderDto order);
    }
}
