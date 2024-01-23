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
        Task<bool> UpdateDishStatus(Guid id, Status status, Guid loggedInUserId);
        Task<bool> UpdateBrandStatus(Guid id, Status status, Guid loggedInUserId);
        Task<bool> UpdateFranchiseStatus(Guid id, Status status, Guid loggedInUserId);
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
            return await _foodsNowDbContext.Orders
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.OrderProductExtraDippings)
                .Include(o => o.OrderProducts)
                    .ThenInclude(p => p.OrderProductExtraToppings)
                .AsSplitQuery()
                .Where(o => o.CustomerId == customerId)
                .OrderByDescending(o => o.CreatedDateTimeUtc)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAllFranchiseOrders(Guid franchiseId)
        {
            return await _foodsNowDbContext.Orders.Include(o => o.OrderProducts)
                .Include(o => o.Customer)
                .Include(o => o.CustomerAdress)
                .Include(o => o.OrderProducts).ThenInclude(p => p.OrderProductExtraDippings)
                .Include(o => o.OrderProducts).ThenInclude(p => p.OrderProductExtraToppings)
                .Where(o => o.FranchiseId == franchiseId)
                .OrderByDescending(o => o.CreatedDateTimeUtc).ToListAsync();
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
            return await _foodsNowDbContext.Orders.Include(o => o.OrderProducts)
                .Include(o => o.OrderProducts).ThenInclude(p => p.OrderProductExtraDippings)
                .Include(o => o.OrderProducts).ThenInclude(p => p.OrderProductExtraToppings)
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

                return true;
            }

            return false;
        }

        public async Task<User> UserLogin(string email, string password)
        {
            var user = await _foodsNowDbContext.Users.FirstOrDefaultAsync(c => c.EmailAdress == email && c.Password == password);

            if (user == null) return null;

            return user;
        }

        public async Task<bool> UpdateDishStatus(Guid Id, Status status, Guid loggedInUserId)
        {
            var dish = await _foodsNowDbContext.Products.FirstAsync(p => p.Id == Id);

            if (dish != null)
            {
                dish.IsActive = status == Status.Active;

                dish.UpdatedById = loggedInUserId;

                _foodsNowDbContext.Products.Update(dish);

                await _foodsNowDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateBrandStatus(Guid Id, Status status, Guid loggedInUserId)
        {
            var brand = await _foodsNowDbContext.Categories.FirstAsync(p => p.Id == Id);

            if (brand != null)
            {
                brand.IsActive = status == Status.Active;

                brand.UpdatedById = loggedInUserId;

                _foodsNowDbContext.Categories.Update(brand);

                await _foodsNowDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateFranchiseStatus(Guid Id, Status status, Guid loggedInUserId)
        {
            var franchise = await _foodsNowDbContext.Franchises.FirstAsync(p => p.Id == Id);

            if (franchise != null)
            {
                franchise.IsActive = status == Status.Active;

                franchise.UpdatedById = loggedInUserId;

                _foodsNowDbContext.Franchises.Update(franchise);

                await _foodsNowDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
