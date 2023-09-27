using FoodsNow.Core.RequestModels;
using FoodsNow.Services;
using FoodsNow.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace FoodsNow.Api
{
    public class FranchiseApi
    {
        private readonly ILogger _logger;
        private readonly ICustomerService _customerService;
        private readonly IJwtTokenManager _jwtTokenManager;

        public FranchiseApi(ILoggerFactory loggerFactory, ICustomerService customerService, IJwtTokenManager jwtTokenManager)
        {
            _logger = loggerFactory.CreateLogger<FranchiseApi>();
            _customerService = customerService;
            _jwtTokenManager = jwtTokenManager;
        }

        
        [Function(nameof(CustomerLogin))]
        public async Task<HttpResponseData> CustomerLogin([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Cutomer Login funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<LoginRequestModel>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.EmailAdress))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.Password))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _customerService.CustomerLogin(request);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }
    }
}
