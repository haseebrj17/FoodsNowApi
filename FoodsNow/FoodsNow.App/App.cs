using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FoodsNow.App
{
    public class App
    {
        private readonly ILogger _logger;

        public App(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<App>();
        }

        [Function(nameof(GetFranhisesByArea))]
        public HttpResponseData GetFranhisesByArea([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
