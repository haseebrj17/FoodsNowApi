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

                newOrder.TotalItems = order.Products.Count;

                newOrder.OrderStatus = Core.Enum.Enums.OrderStatus.OrderPlaced;

                newOrder = await _orderRepository.AddOrder(newOrder);

                decimal orderTotal = 0;

                foreach (var product in order.Products)
                {
                    product.OrderId = newOrder.Id;

                    var newProduct = _mapper.Map<OrderProductDto, OrderProduct>(product);

                    newProduct.UnitPrice = await _orderRepository.GetProductPrice(product.ProductId);

                    orderTotal += newProduct.UnitPrice * newProduct.Quantity;

                    newProduct = await _orderRepository.AddProduct(newProduct);

                    if (product.ProductExtraDippings != null)
                    {
                        foreach (var extraDipping in product.ProductExtraDippings)
                        {
                            extraDipping.OrderProductId = newProduct.Id;

                            var newExtraDipping = _mapper.Map<OrderProductExtraDippingDto, OrderProductExtraDipping>(extraDipping);

                            newExtraDipping.UnitPrice = await _orderRepository.GetProductExtraDippingPrice(extraDipping.ProductExtraDippingPriceId);

                            await _orderRepository.AddProductExtraDipping(newExtraDipping);

                            orderTotal += newExtraDipping.UnitPrice * newExtraDipping.Quantity;
                        }
                    }
                    if (product.ProductExtraToppings != null)
                    {
                        foreach (var extraTopping in product.ProductExtraToppings)
                        {
                            extraTopping.OrderProductId = newProduct.Id;

                            var newExtraTopping = _mapper.Map<OrderProductExtraToppingDto, OrderProductExtraTopping>(extraTopping);

                            newExtraTopping.UnitPrice = await _orderRepository.GetProductExtraDippingPrice(extraTopping.ProductExtraToppingPriceId);

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
