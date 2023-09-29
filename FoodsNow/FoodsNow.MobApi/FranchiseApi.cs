using FoodsNow.Core.RequestModels;
using FoodsNow.Services;
using FoodsNow.Services.Interfaces;
using FoodsNow.Services.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Api
{
    public class FranchiseApi
    {
        private readonly ILogger _logger;
        private readonly IFranchiseService _franchiseService;
        private readonly IJwtTokenManager _jwtTokenManager;

        public FranchiseApi(ILoggerFactory loggerFactory, IFranchiseService franchiseService, IJwtTokenManager jwtTokenManager)
        {
            _logger = loggerFactory.CreateLogger<FranchiseApi>();
            _franchiseService = franchiseService;
            _jwtTokenManager = jwtTokenManager;
        }


        [Function(nameof(UserLogin))]
        public async Task<HttpResponseData> UserLogin([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling User Login funtion");

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

            var data = await _franchiseService.UserLogin(request);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(GetAllFranchiseOrders))]
        public async Task<HttpResponseData> GetAllFranchiseOrders([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetAllFranchiseOrders funtion");

            var loggedInUser = _jwtTokenManager.ValidateToken(req, new List<UserRole> { UserRole.FranchiseManager, UserRole.SuperAdmin, UserRole.Client, UserRole.FranchiseUser });

            if (loggedInUser == null)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            if (loggedInUser.FranchiseId == null || loggedInUser.FranchiseId == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            var data = await _franchiseService.GetAllFranchiseOrders(loggedInUser.FranchiseId.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(GetOrderDetail))]
        public async Task<HttpResponseData> GetOrderDetail([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetOrderDetail funtion");

            var loggedInUser = _jwtTokenManager.ValidateToken(req, new List<UserRole> { UserRole.FranchiseManager, UserRole.SuperAdmin, UserRole.Client, UserRole.FranchiseUser });

            if (loggedInUser == null)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            if (loggedInUser.FranchiseId == null || loggedInUser.FranchiseId == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CommonRequest>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Id == null || request.Id == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _franchiseService.GetOrderDetail(request.Id.Value, loggedInUser.FranchiseId.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }


    }
}
