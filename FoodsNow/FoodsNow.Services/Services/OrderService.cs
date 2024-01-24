using AutoMapper;
using FoodsNow.Core.Dto;
using FoodsNow.DbEntities.Models;
using FoodsNow.DbEntities.Repositories;
using FoodsNow.Services.Interfaces;

namespace FoodsNow.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, ICustomerAddressRepository customerAddressRepository,
            ICustomerRepository customerRepository, IFranchiseRepository franchiseRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _customerAddressRepository = customerAddressRepository;
            _customerRepository = customerRepository;
            _franchiseRepository = franchiseRepository;
        }

        public async Task<Guid?> PlaceOrder(OrderDto orderDto)
        {
            try
            {
                var order = _mapper.Map<OrderDto, Order>(orderDto);

                var customer = await _customerRepository.GetById(orderDto.CustomerId) ?? throw new InvalidOperationException("Customer not found.");

                var customerAddress = await _customerAddressRepository.GetAddressById(orderDto.CustomerAddressId, orderDto.CustomerId) ?? throw new InvalidOperationException("Customer address not found.");

                var franchiseSettings = await _franchiseRepository.GetFranchiseSettingById(orderDto.FranchiseId) ?? throw new InvalidOperationException("Franchise not found.");

                decimal totalBill = 0;

                order.TotalItems = orderDto.CustomerOrderedPackage.TotalNumberOfMeals;
                order.OrderDeliveryDateTime = orderDto.OrderDeliveryDateTime;
                order.Instructions = orderDto.Instructions;
                order.CustomerId = customer.Id;
                order.CustomerAddressId = customerAddress.Id;
                order.FranchiseId = orderDto.FranchiseId;
                order.CreatedDateTimeUtc = DateTime.UtcNow;
                order.UpdatedDateTimeUtc = DateTime.UtcNow;
                order.OrderStatus = FoodsNow.Core.Enum.Enums.OrderStatus.OrderPlaced;
                order.CustomerDetails = new CustomerDetails
                {
                    CustomerFullName = customer.FullName,
                    CustomerEmailAddress = customer.EmailAddress,
                    CustomerContactNumber = customer.ContactNumber,
                    CustomerAddressDetail = new CustomerAddressDetail
                    {
                        StreetAddress = customerAddress.StreetAddress,
                        House = customerAddress.House,
                        PostalCode = customerAddress.PostalCode,
                        CityName = customerAddress.CityName,
                        District = customerAddress.District,
                        UnitNumber = customerAddress.UnitNumber,
                        FloorNumber = customerAddress.FloorNumber,
                        StateName = customerAddress.StateName,
                        CountryName = customerAddress.CountryName,
                        Notes = customerAddress.Notes,
                        Latitude = customerAddress.Latitude,
                        Longitude = customerAddress.Longitude,
                        CityId = customerAddress.CityId
                    }
                };

                order.CustomerOrderPromo = new CustomerOrderPromo
                {
                    Type = orderDto.CustomerOrderPromo.Type,
                    Name = orderDto.CustomerOrderPromo.Name,
                    Percent = orderDto.CustomerOrderPromo.Percent
                };

                order.CustomerOrderPayment = new CustomerOrderPayment
                {
                    PaymentType = orderDto.CustomerOrderPayment.PaymentType,
                    OrderType = orderDto.CustomerOrderPayment.OrderType
                };

                foreach (var customerDeviceDto in customer.CustomerDevice)
                {
                    var customerDevices = new CustomerDevice
                    {
                        DeviceId = customerDeviceDto.DeviceId,
                        IsActive = customerDeviceDto.IsActive
                    };
                    order.CustomerDevice.Add(customerDevices);
                }

                foreach (var orderPorductDto in orderDto.OrderProducts)
                {
                    var orderProduct = new OrderProducts
                    {
                        Name = orderPorductDto.Name,
                        Detail = orderPorductDto.Detail,
                        EstimatedDeliveryTime = orderPorductDto.EstimatedDeliveryTime,
                        SpiceLevel = orderPorductDto.SpiceLevel,
                        IngredientSummary = orderPorductDto.IngredientSummary,
                        Image = orderPorductDto.Image,
                        Price = orderPorductDto.Price,
                        OrderedProductExtraDipping = orderPorductDto.OrderedProductExtraDipping.Select(dip => new OrderedProductExtraDipping
                        {
                            Name = dip.Name,
                            Price = dip.Price
                        }).ToList(),

                        OrderedProductExtraTopping = orderPorductDto.OrderedProductExtraTopping.Select(top => new OrderedProductExtraTopping
                        {
                            Name = top.Name,
                            Price = top.Price
                        }).ToList(),
                    };

                    totalBill += orderProduct.Price;
                    if (orderProduct.OrderedProductExtraDipping != null) totalBill += orderProduct.OrderedProductExtraDipping.Sum(dip => dip.Price);
                    if (orderProduct.OrderedProductExtraTopping != null) totalBill += orderProduct.OrderedProductExtraTopping.Sum(top => top.Price);

                    order?.OrderProducts?.Add(orderProduct);
                }

                order.TotalBill = totalBill;

                await _orderRepository.AddOrder(order);

                return order.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}