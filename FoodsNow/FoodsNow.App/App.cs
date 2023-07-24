using System.Data.Entity.Core.Objects;
using System.Net;
using FoodsNow.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FoodsNow.App
{
    public class App
    {
        private readonly ILogger _logger;
        private readonly IAppService _appService;

        public App(ILoggerFactory loggerFactory, IAppService appService)
        {
            _logger = loggerFactory.CreateLogger<App>();
            _appService = appService;
        }

        [Function(nameof(GetAppDashboardData))]
        public async Task<IActionResult> GetAppDashboardData([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetAppDashboardData funtion");

            var data = await _appService.GetHomeData(0, 0);

            return new OkObjectResult(data);
        }
    }
}
