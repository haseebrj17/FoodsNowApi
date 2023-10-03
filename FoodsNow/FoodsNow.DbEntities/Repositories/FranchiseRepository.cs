using FoodsNow.DbEntities.Models;
using Microsoft.EntityFrameworkCore;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.DbEntities.Repositories
{
    public interface IFranchiseRepository
    {
        Task<Franchise> GetFranchiseDetail(decimal latidude, decimal longitude);
        Task<List<Franchise>> GetClientFranchises(Guid clientId);
        Task<List<Order>> GetAllFranchiseOrders(Guid franchiseId);
        Task<List<Order>> GetCustomerOrders(Guid customerId);
        Task<Order> GetOrderDetail(Guid orderId, Guid franchiseId);
        Task<bool> UpdateOrderStatus(Guid orderId, OrderStatus orderStatus, Guid loggedInUserId);
        Task<User> UserLogin(string email, string password);
    }
    public class FranchiseRepository : IFranchiseRepository
    {
        private readonly FoodsNowDbContext _foodsNowDbContext;
        public FranchiseRepository(FoodsNowDbContext foodsNowDbContext)
        {
            _foodsNowDbContext = foodsNowDbContext;
        }

        public async Task<List<Order>> GetCustomerOrders(Guid customerId)
        {
            return await _foodsNowDbContext.Orders.Include(o => o.OrderProducts).ThenInclude(p => p.Product)                
                .Include(o => o.OrderProducts).ThenInclude(p => p.OrderProductExtraDippings)
                .Include(o => o.OrderProducts).ThenInclude(p => p.OrderProductExtraToppings)
                .Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Order>> GetAllFranchiseOrders(Guid franchiseId)
        {
            return await _foodsNowDbContext.Orders.Include(o => o.CustomerAdress).Include(o => o.OrderProducts)
                .ThenInclude(p => p.OrderProductExtraDippings).Include(o => o.OrderProducts).ThenInclude(p => p.OrderProductExtraToppings).ToListAsync();
        }

        public async Task<List<Franchise>> GetClientFranchises(Guid clientId)
        {
            return await _foodsNowDbContext.Franchises.Where(f => f.ClientId == clientId && f.IsActive).ToListAsync();
        }

        public async Task<Franchise> GetFranchiseDetail(decimal latidude, decimal longitude)
        {
            //Todo: get by lati longi
            return await _foodsNowDbContext.Franchises.FirstAsync();//.FindAsync(latidude, longitude);
        }

        public async Task<Order> GetOrderDetail(Guid orderId, Guid franchiseId)
        {
            return await _foodsNowDbContext.Orders.Include(o => o.Customer).Include(o => o.CustomerAdress).Include(o => o.OrderProducts)
                .ThenInclude(p => p.OrderProductExtraDippings).Include(o => o.OrderProducts).ThenInclude(p => p.OrderProductExtraToppings)
                .FirstAsync(o => o.Id == orderId && o.FranchiseId == franchiseId);
        }

        public async Task<bool> UpdateOrderStatus(Guid orderId, OrderStatus orderStatus, Guid loggedInUserId)
        {
            var order = await _foodsNowDbContext.Orders.FirstAsync(o => o.Id == orderId);

            if (order != null)
            {
                order.OrderStatus = orderStatus;

                order.UpdatedById = loggedInUserId;

                _foodsNowDbContext.Orders.Update(order);

                await _foodsNowDbContext.SaveChangesAsync();
            }

            return false;
        }

        public async Task<User> UserLogin(string email, string password)
        {
            var user = await _foodsNowDbContext.Users.FirstOrDefaultAsync(c => c.EmailAdress == email && c.Password == password);

            if (user == null) return null;

            return user;
        }
    }
}
