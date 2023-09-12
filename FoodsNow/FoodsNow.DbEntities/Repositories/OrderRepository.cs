using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrder(Order order);
        public Task<Order> UpdateOrder(Order order);
        public Task<OrderProduct> AddProduct(OrderProduct product);
        public Task<Decimal> GetProductPrice(Guid productId);
        public Task<Decimal> GetProductExtraDippingPrice(Guid productId);
        public Task<Decimal> GetProductExtraToppingPrice(Guid productId);
        public Task<OrderProductExtraDipping> AddProductExtraDipping(OrderProductExtraDipping product);
        public Task<OrderProductExtraTopping> AddProductExtraTopping(OrderProductExtraTopping product);
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

        public async Task<decimal> GetProductExtraDippingPrice(Guid productId)
        {
            var product = await _foodsNowDbContext.ProductExtraDippingPrices.FirstAsync(p => p.ProductExtraDippingId == productId);
            return product.Price;
        }

        public async Task<decimal> GetProductExtraToppingPrice(Guid productId)
        {
            var product = await _foodsNowDbContext.ProductExtraToppingPrices.FirstAsync(p => p.ProductExtraToppingId == productId);
            return product.Price;
        }

        public async Task<decimal> GetProductPrice(Guid productId)
        {
            var product = await _foodsNowDbContext.ProductPrices.FirstAsync(p => p.ProductId == productId);
            return product.Price;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _foodsNowDbContext.Orders.Update(order);

            await _foodsNowDbContext.SaveChangesAsync();

            return order;
        }
    }
}
