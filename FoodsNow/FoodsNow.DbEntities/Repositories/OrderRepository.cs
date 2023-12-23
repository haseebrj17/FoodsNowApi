using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrder(Order order);
        public Task<Order> UpdateOrder(Order order);
        public Task<OrderProduct> AddProduct(OrderProduct product);
        public Task<ProductPrice> GetProductPriceDetail(Guid id);
        public Task<ProductExtraDippingPrice> GetProductExtraDippingPriceDetail(Guid id);
        public Task<ProductExtraToppingPrice> GetProductExtraToppingPriceDetail(Guid id);
        public Task<OrderProductExtraDipping> AddProductExtraDipping(OrderProductExtraDipping product);
        public Task<OrderProductExtraTopping> AddProductExtraTopping(OrderProductExtraTopping product);
        public Task<Order> GetOrderById(Guid orderId);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public OrderRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _foodsNowDbContext.Orders.AddAsync(order);

            await _foodsNowDbContext.SaveChangesAsync();

            return order;
        }

        public async Task<OrderProduct> AddProduct(OrderProduct product)
        {
            await _foodsNowDbContext.OrderProducts.AddAsync(product);

            await _foodsNowDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<OrderProductExtraDipping> AddProductExtraDipping(OrderProductExtraDipping product)
        {
            await _foodsNowDbContext.OrderProductExtraDippings.AddAsync(product);

            await _foodsNowDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<OrderProductExtraTopping> AddProductExtraTopping(OrderProductExtraTopping product)
        {
            await _foodsNowDbContext.OrderProductExtraToppings.AddAsync(product);

            await _foodsNowDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<ProductExtraDippingPrice> GetProductExtraDippingPriceDetail(Guid id)
        {
            return await _foodsNowDbContext.ProductExtraDippingPrices.FirstAsync(p => p.Id == id);
        }

        public async Task<ProductExtraToppingPrice> GetProductExtraToppingPriceDetail(Guid id)
        {
            return await _foodsNowDbContext.ProductExtraToppingPrices.FirstAsync(p => p.Id == id);
        }

        public async Task<ProductPrice> GetProductPriceDetail(Guid id)
        {
            return await _foodsNowDbContext.ProductPrices.FirstAsync(p => p.Id == id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _foodsNowDbContext.Orders.Update(order);

            await _foodsNowDbContext.SaveChangesAsync();

            return order;
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            return await _foodsNowDbContext.Orders
                .Include(o => o.Customer)
                .FirstAsync(o => o.Id == orderId);
        }
    }
}
