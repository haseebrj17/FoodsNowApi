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
        private readonly ICustomerService _customerService;

        public OrderApi(ILoggerFactory loggerFactory, ICustomerService customerService)
        {
            _logger = loggerFactory.CreateLogger<CustomerApi>();
            _customerService = customerService;
        }

        [Function(nameof(PlaceOrder))]
        public async Task<HttpResponseData> PlaceOrder([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Register funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CustomerDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.ContactNumber))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            //var data = await _customerService.AddCustomer(request);

            var response = req.CreateResponse(HttpStatusCode.OK);
            //if (data == null)
            //{
            //    await response.WriteAsJsonAsync(new { isSuccess = false, ErrorMessage = "Customer with this detail already exist" });
            //}
            //else
            //{
            //    await response.WriteAsJsonAsync(new { isSuccess = true, data });

            //}

            return response;
        }
    }
}
