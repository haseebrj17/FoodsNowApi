using System.Net;
using FoodsNow.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FoodsNow.MobApi
{
    public class MobApiFunctionApp
    {
        private readonly ILogger _logger;
        //private readonly IAppService _appService;

        public MobApiFunctionApp(ILoggerFactory loggerFactory)//, IAppService appService)
        {
            _logger = loggerFactory.CreateLogger<MobApiFunctionApp>();
            //_appService = appService;
        }

        [Function(nameof(GetAppDashboardData))]
        public async Task<HttpResponseData> GetAppDashboardData([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetAppDashboardData funtion");

            var data = new List<string> {"a","b" };// await _appService.GetHomeData(0, 0);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }
    }
}
