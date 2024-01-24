using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrder(Order order);
        public Task<Order> UpdateOrder(Order order);
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
            try
            {
                await _foodsNowDbContext.Orders.AddAsync(order);
                await _foodsNowDbContext.SaveChangesAsync();
                return order;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("Error adding order to the database.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            try
            {
                _foodsNowDbContext.Orders.Update(order);
                await _foodsNowDbContext.SaveChangesAsync();
                return order;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("The order was not found or has been modified.", ex);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("Error updating order in the database.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            return await _foodsNowDbContext.Orders
                .FirstAsync(o => o.Id == orderId);
        }

    }
}
