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
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<Guid?> PlaceOrder(OrderDto order)
        {
            try
            {
                

                var newOrder = _mapper.Map<OrderDto, Order>(order);

                newOrder.CreatedDateTimeUtc = DateTime.UtcNow;

                newOrder.UpdatedDateTimeUtc = DateTime.UtcNow;

                newOrder.CreatedById = newOrder.CustomerId;

                newOrder.UpdatedById = newOrder.CustomerId;

                newOrder.TotalItems = order.OrderProducts.Count;

                newOrder.OrderStatus = Core.Enum.Enums.OrderStatus.OrderPlaced;

                newOrder = await _orderRepository.AddOrder(newOrder);

                decimal orderTotal = 0;

                foreach (var product in order.OrderProducts)
                {
                    product.OrderId = newOrder.Id;

                    var newProduct = _mapper.Map<OrderProductDto, OrderProduct>(product);

                    newProduct.UnitPrice = await _orderRepository.GetProductPrice(product.ProductPriceId);

                    orderTotal += newProduct.UnitPrice * newProduct.Quantity;

                    newProduct.CreatedDateTimeUtc = DateTime.UtcNow;

                    newProduct.UpdatedDateTimeUtc = DateTime.UtcNow;

                    newProduct.CreatedById = newOrder.CustomerId;

                    newProduct.UpdatedById = newOrder.CustomerId;

                    newProduct = await _orderRepository.AddProduct(newProduct);

                    if (product.OrderProductExtraDippings != null)
                    {
                        foreach (var extraDipping in product.OrderProductExtraDippings)
                        {
                            extraDipping.OrderProductId = newProduct.Id;

                            var newExtraDipping = _mapper.Map<OrderProductExtraDippingDto, OrderProductExtraDipping>(extraDipping);

                            newExtraDipping.UnitPrice = await _orderRepository.GetProductExtraDippingPrice(extraDipping.ProductExtraDippingPriceId);

                            newExtraDipping.CreatedDateTimeUtc = DateTime.UtcNow;

                            newExtraDipping.UpdatedDateTimeUtc = DateTime.UtcNow;

                            newExtraDipping.CreatedById = newOrder.CustomerId;

                            newExtraDipping.UpdatedById = newOrder.CustomerId;

                            await _orderRepository.AddProductExtraDipping(newExtraDipping);

                            orderTotal += newExtraDipping.UnitPrice * newExtraDipping.Quantity;
                        }
                    }
                    if (product.OrderProductExtraToppings != null)
                    {
                        foreach (var extraTopping in product.OrderProductExtraToppings)
                        {
                            extraTopping.OrderProductId = newProduct.Id;

                            var newExtraTopping = _mapper.Map<OrderProductExtraToppingDto, OrderProductExtraTopping>(extraTopping);

                            newExtraTopping.UnitPrice = await _orderRepository.GetProductExtraToppingPrice(extraTopping.ProductExtraToppingPriceId);

                            newExtraTopping.CreatedDateTimeUtc = DateTime.UtcNow;

                            newExtraTopping.UpdatedDateTimeUtc = DateTime.UtcNow;

                            newExtraTopping.CreatedById = newOrder.CustomerId;

                            newExtraTopping.UpdatedById = newOrder.CustomerId;

                            await _orderRepository.AddProductExtraTopping(newExtraTopping);

                            orderTotal += newExtraTopping.UnitPrice * newExtraTopping.Quantity;
                        }
                    }
                }

                newOrder.TotalBill = orderTotal;

                newOrder = await _orderRepository.UpdateOrder(newOrder);


                return newOrder.Id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
