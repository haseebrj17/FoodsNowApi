using System.Net;
using System.Text.Json;
using FoodsNow.Core.RequestModels;
using FoodsNow.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FoodsNow.MobApi
{
    public class MobApiFunctionApp
    {
        private readonly ILogger _logger;
        private readonly IAppService _appService;

        public MobApiFunctionApp(ILoggerFactory loggerFactory, IAppService appService)
        {
            _logger = loggerFactory.CreateLogger<MobApiFunctionApp>();
            _appService = appService;
        }

        [Function(nameof(GetClientFranchises))]
        public async Task<HttpResponseData> GetClientFranchises([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetClientFranchises funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CommonRequest>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Id == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _appService.GetClientFranchises(request.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(GetAppDashboardData))]
        public async Task<HttpResponseData> GetAppDashboardData([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetAppDashboardData funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CommonRequest>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Id == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _appService.GetAppHomeData(request.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(GetProducts))]
        public async Task<HttpResponseData> GetProducts([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetProducts funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CommonRequest>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Id == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _appService.GetProducts(request.Id.Value, request.AddSides.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(GetProduct))]
        public async Task<HttpResponseData> GetProduct([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetProduct funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CommonRequest>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Id == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _appService.GetProductById(request.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(GetProductsById))]
        public async Task<HttpResponseData> GetProductsById([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetProductsById funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CommonRequest>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Ids == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _appService.GetProductsById(request.Ids);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }
    }
}
