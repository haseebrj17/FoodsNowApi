using AutoMapper;
using FoodsNow.Core;
using FoodsNow.Core.Dto;
using FoodsNow.Core.Enum;
using FoodsNow.Core.RequestModels;
using FoodsNow.Core.ResponseModels;
using FoodsNow.DbEntities.Models;
using FoodsNow.DbEntities.Repositories;
using FoodsNow.Services.Interfaces;

namespace FoodsNow.Services.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IMapper _mapper;
        private readonly IJwtTokenManager _jwtTokenManager;

        public FranchiseService(IMapper mapper, IFranchiseRepository franchiseRepository,
                 IJwtTokenManager jwtTokenManager)
        {
            _mapper = mapper;
            _franchiseRepository = franchiseRepository;
            _jwtTokenManager = jwtTokenManager;
        }

        public async Task<List<OrderDto>> GetAllFranchiseOrders(Guid franchiseId)
        {
            var orders = await _franchiseRepository.GetAllFranchiseOrders(franchiseId);

            return _mapper.Map<List<Order>, List<OrderDto>>(orders);
        }

        public async Task<List<OrderDetailDto>> GetCustomerOrders(Guid customerId)
        {
            var orders = await _franchiseRepository.GetCustomerOrders(customerId);

            var customerOrdrs = _mapper.Map<List<Order>, List<OrderDetailDto>>(orders);

            foreach (var order in customerOrdrs)
            {
                order.Products = orders.First(o => o.Id == order.Id).OrderProducts
                    .Select(p => new OrderDetailProductDto() { Name = p.Product.Name, Price = p.UnitPrice, Quanity = p.Quantity, Id = p.ProductId }).ToList();

                foreach (var product in order.Products)
                {
                    product.ExtraDippingProducts = orders.First(o => o.Id == order.Id).OrderProducts.FirstOrDefault(p => p.ProductId == product.Id)
                        .OrderProductExtraDippings.Select(p => new OrderDetailProductExtraDto
                        {
                            Name = p.OrderProduct.Product.Name,
                            Quanity = p.Quantity,
                            Price = p.UnitPrice
                        }).ToList();

                    product.ExtraToppingProducts = orders.First(o => o.Id == order.Id).OrderProducts.FirstOrDefault(p => p.ProductId == product.Id)
                        .OrderProductExtraToppings.Select(p => new OrderDetailProductExtraDto
                        {
                            Name = p.OrderProduct.Product.Name,
                            Quanity = p.Quantity,
                            Price = p.UnitPrice
                        }).ToList();
                }
            }

            return customerOrdrs;
        }

        public async Task<OrderDto> GetOrderDetail(Guid orderId, Guid franchiseId)
        {
            var order = await _franchiseRepository.GetOrderDetail(orderId, franchiseId);

            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task<bool> UpdateOrderStatus(Guid orderId, Enums.OrderStatus orderStatus, Guid loggedInUserId)
        {
            return await _franchiseRepository.UpdateOrderStatus(orderId, orderStatus, loggedInUserId);
        }

        public async Task<LoginResponse> UserLogin(LoginRequestModel loginRequest)
        {
            var userDetails = await _franchiseRepository.UserLogin(loginRequest.EmailAdress, loginRequest.Password);

            if (userDetails == null) { return new LoginResponse() { IsLoggedIn = false }; }

            var currentAppUser = _mapper.Map<User, CurrentAppUser>(userDetails);

            currentAppUser.UserRole = userDetails.UserRole;

            currentAppUser.ContactNumber = "";
            currentAppUser.FranchiseId = userDetails.FranchiseId;
            currentAppUser.FullName = userDetails.FirstName + " " + userDetails.LastName;

            var token = _jwtTokenManager.GenerateToken(currentAppUser);

            return new LoginResponse() { IsLoggedIn = true, Token = token };
        }
    }
}
