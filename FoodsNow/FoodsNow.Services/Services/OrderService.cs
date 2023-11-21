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
        private readonly IProductRepository _productRepository;
        private readonly IProductExtraDippingRepository _productExtraDippingRepository;
        private readonly IProductExtraToppingRepository _productExtraToppingRepository;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, IProductRepository productRepository, IProductExtraDippingRepository productExtraDippingRepository,
            IProductExtraToppingRepository productExtraToppingRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _productExtraDippingRepository = productExtraDippingRepository;
            _productExtraToppingRepository = productExtraToppingRepository;
        }

        public async Task<Guid?> PlaceOrder(OrderDto order)
        {
            try
            {
                var orderDetail = _mapper.Map<OrderDto, Order>(order);

                var newOrder = new Order()
                {
                    CustomerId = orderDetail.CustomerId,
                    CustomerAddressId = orderDetail.CustomerAddressId,
                    FranchiseId = orderDetail.FranchiseId,
                    CreatedDateTimeUtc = DateTime.UtcNow,
                    UpdatedDateTimeUtc = DateTime.UtcNow,
                    CreatedById = orderDetail.CustomerId,
                    UpdatedById = orderDetail.CustomerId,
                    TotalItems = order.OrderProducts.Count,
                    OrderStatus = Core.Enum.Enums.OrderStatus.OrderPlaced,
                    Instructions = orderDetail.Instructions,
                    OrderDeliveryDateTime = orderDetail.OrderDeliveryDateTime
                };

                orderDetail = await _orderRepository.AddOrder(newOrder);

                decimal orderTotal = 0;

                foreach (var product in order.OrderProducts)
                {
                    var productDetail = await _productRepository.GetProductById(product.ProductId);

                    product.OrderId = orderDetail.Id;

                    var newProduct = _mapper.Map<OrderProductDto, OrderProduct>(product);

                    newProduct.OrderProductExtraDippings = null;

                    newProduct.OrderProductExtraToppings = null;

                    newProduct.Name = productDetail.Name;

                    var productPriceDetail = await _orderRepository.GetProductPriceDetail(product.ProductPriceId);

                    newProduct.UnitPrice = productPriceDetail.Price;

                    newProduct.PriceDetail = productPriceDetail.Description;

                    orderTotal += newProduct.UnitPrice * newProduct.Quantity;

                    newProduct.CreatedDateTimeUtc = DateTime.UtcNow;

                    newProduct.UpdatedDateTimeUtc = DateTime.UtcNow;

                    newProduct.CreatedById = orderDetail.CustomerId;

                    newProduct.UpdatedById = orderDetail.CustomerId;

                    newProduct = await _orderRepository.AddProduct(newProduct);

                    if (product.OrderProductExtraDippings != null)
                    {
                        foreach (var extraDipping in product.OrderProductExtraDippings)
                        {

                            var extraDippingDetail = await _productExtraDippingRepository.GetProductExtraDippingById(extraDipping.ProductExtraDippingId);

                            extraDipping.OrderProductId = newProduct.Id;

                            var newExtraDipping = _mapper.Map<OrderProductExtraDippingDto, OrderProductExtraDipping>(extraDipping);

                            newExtraDipping.Name = extraDippingDetail.Name;

                            var productDippingPriceDetail = await _orderRepository.GetProductExtraDippingPriceDetail(extraDipping.ProductExtraDippingPriceId);

                            newExtraDipping.UnitPrice = productDippingPriceDetail.Price;

                            newExtraDipping.PriceDetail = productDippingPriceDetail.Description;

                            newExtraDipping.CreatedDateTimeUtc = DateTime.UtcNow;

                            newExtraDipping.UpdatedDateTimeUtc = DateTime.UtcNow;

                            newExtraDipping.CreatedById = orderDetail.CustomerId;

                            newExtraDipping.UpdatedById = orderDetail.CustomerId;

                            await _orderRepository.AddProductExtraDipping(newExtraDipping);

                            orderTotal += newExtraDipping.UnitPrice * newExtraDipping.Quantity;
                        }
                    }
                    if (product.OrderProductExtraToppings != null)
                    {
                        foreach (var extraTopping in product.OrderProductExtraToppings)
                        {
                            var extraToppingDetail = await _productExtraToppingRepository.GetProductExtraToppingById(extraTopping.ProductExtraToppingId);

                            extraTopping.OrderProductId = newProduct.Id;

                            var newExtraTopping = _mapper.Map<OrderProductExtraToppingDto, OrderProductExtraTopping>(extraTopping);

                            newExtraTopping.Name = extraToppingDetail.Name;

                            var productToppingPriceDetail = await _orderRepository.GetProductExtraToppingPriceDetail(extraTopping.ProductExtraToppingPriceId);

                            newExtraTopping.UnitPrice = productToppingPriceDetail.Price;

                            newExtraTopping.PriceDetail = productToppingPriceDetail.Description;

                            newExtraTopping.CreatedDateTimeUtc = DateTime.UtcNow;

                            newExtraTopping.UpdatedDateTimeUtc = DateTime.UtcNow;

                            newExtraTopping.CreatedById = orderDetail.CustomerId;

                            newExtraTopping.UpdatedById = orderDetail.CustomerId;

                            await _orderRepository.AddProductExtraTopping(newExtraTopping);

                            orderTotal += newExtraTopping.UnitPrice * newExtraTopping.Quantity;
                        }
                    }
                }

                orderDetail.TotalBill = orderTotal;

                orderDetail = await _orderRepository.UpdateOrder(orderDetail);


                return orderDetail.Id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
