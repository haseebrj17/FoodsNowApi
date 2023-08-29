using FoodsNow.Core.RequestModels;
using FoodsNow.Services.Interfaces;
using FoodsNow.Services.Services;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace FoodsNow.Api
{
    public class CustomerApi
    {
        private readonly ILogger _logger;
        private readonly ICustomerService _customerService;

        public CustomerApi(ILoggerFactory loggerFactory, ICustomerService customerService)
        {
            _logger = loggerFactory.CreateLogger<CustomerApi>();
            _customerService = customerService;
        }

        [Function(nameof(Register))]
        public async Task<HttpResponseData> Register([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Register funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CommonRequest>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Id == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            //var data = await _appService.GetClientFranchises(request.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            //await response.WriteAsJsonAsync(data);

            return response;
        }
    }
}
