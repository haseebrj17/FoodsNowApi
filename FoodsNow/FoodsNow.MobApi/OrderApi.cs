using FoodsNow.Core.Dto;
using FoodsNow.Services;
using FoodsNow.Services.Interfaces;
using FoodsNow.Services.Services;
using Grpc.Core;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Api
{
    public class OrderApi
    {
        private readonly ILogger _logger;
        private readonly IOrderService _orderService;
        private readonly IFranchiseService _franchiseService;
        private readonly IJwtTokenManager _jwtTokenManager;
        public OrderApi(ILoggerFactory loggerFactory, IOrderService orderService, IJwtTokenManager jwtTokenManager, IFranchiseService franchiseService)
        {
            _logger = loggerFactory.CreateLogger<CustomerApi>();
            _orderService = orderService;
            _jwtTokenManager = jwtTokenManager;
            _franchiseService = franchiseService;
        }

        [Function(nameof(PlaceOrder))]
        public async Task<HttpResponseData> PlaceOrder([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {

            _logger.LogInformation("Calling PlaceOrder funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            var loggedInUser = _jwtTokenManager.ValidateToken(req, new List<UserRole> { UserRole.Customer });

            if (loggedInUser == null)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<OrderDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Products == null || !request.Products.Any())
                return req.CreateResponse(HttpStatusCode.BadRequest);

            request.CustomerId = loggedInUser.Id;

            var data = await _orderService.PlaceOrder(request);

            var response = req.CreateResponse(HttpStatusCode.OK);

            if (data == null || data == Guid.Empty)
            {
                await response.WriteAsJsonAsync(new { isSuccess = false, ErrorMessage = "Order failed" });
            }
            else
            {
                await response.WriteAsJsonAsync(new { isSuccess = true, data });

            }

            return response;
        }

        [Function(nameof(GetCustomerOrders))]
        public async Task<HttpResponseData> GetCustomerOrders([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetCustomerOrders funtion");

            var loggedInUser = _jwtTokenManager.ValidateToken(req, new List<UserRole> { UserRole.Customer });

            if (loggedInUser == null)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            var data = await _franchiseService.GetCustomerOrders(loggedInUser.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

    }
}
