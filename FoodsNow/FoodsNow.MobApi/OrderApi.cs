using FoodsNow.Core.Dto;
using FoodsNow.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace FoodsNow.Api
{
    public class OrderApi
    {
        private readonly ILogger _logger;
        private readonly IOrderService _orderService;

        public OrderApi(ILoggerFactory loggerFactory, IOrderService orderService)
        {
            _logger = loggerFactory.CreateLogger<CustomerApi>();
            _orderService = orderService;
        }

        [Function(nameof(PlaceOrder))]
        public async Task<HttpResponseData> PlaceOrder([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling PlaceOrder funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<OrderDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Products == null || !request.Products.Any())
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _orderService.PlaceOrder(request);

            var response = req.CreateResponse(HttpStatusCode.OK);

            if (data == Guid.Empty)
            {
                await response.WriteAsJsonAsync(new { isSuccess = false, ErrorMessage = "Order failed" });
            }
            else
            {
                await response.WriteAsJsonAsync(new { isSuccess = true, data });

            }

            return response;
        }
    }
}
