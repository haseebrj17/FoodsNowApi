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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            _logger.LogInformation("Calling User Login function");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<LoginRequestModel>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.EmailAddress))
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
            _logger.LogInformation("Calling GetAllFranchiseOrders function");

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

        [Function(nameof(GetFranchiseById))]
        public async Task<HttpResponseData> GetFranchiseById([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetFranchiseById function");

            var loggedInUser = _jwtTokenManager.ValidateToken(req, new List<UserRole> { UserRole.FranchiseManager, UserRole.SuperAdmin, UserRole.Client, UserRole.FranchiseUser });

            if (loggedInUser == null)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            if (loggedInUser.FranchiseId == null || loggedInUser.FranchiseId == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            var data = await _franchiseService.GetFranchiseById(loggedInUser.FranchiseId.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }


        [Function(nameof(UpdateOrderStatus))]
        public async Task<HttpResponseData> UpdateOrderStatus([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling UpdateOrderStatus function");

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

            if (request.OrderId == null || request.OrderId == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.OrderStatus == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _franchiseService.UpdateOrderStatus(request.OrderId.Value, Enum.Parse<OrderStatus>(request.OrderStatus.Value.ToString()), loggedInUser.FranchiseId.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(GetAllCategories))]
        public async Task<HttpResponseData> GetAllCategories([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetAllCategories function");

            var loggedInUser = _jwtTokenManager.ValidateToken(req, new List<UserRole> { UserRole.FranchiseManager, UserRole.SuperAdmin, UserRole.Client, UserRole.FranchiseUser });

            if (loggedInUser == null)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            if (loggedInUser.FranchiseId == null || loggedInUser.FranchiseId == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            //var data = await _franchiseService.GetOrderDetail(request.Id.Value, loggedInUser.FranchiseId.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            //await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(UpdateDishStatus))]
        public async Task<HttpResponseData> UpdateDishStatus([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling UpdateDishStatus function");

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

            if (request.Status == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _franchiseService.UpdateDishStatus(request.Id.Value, Enum.Parse<Status>(request.Status.Value.ToString()), loggedInUser.FranchiseId.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(UpdateBrandStatus))]
        public async Task<HttpResponseData> UpdateBrandStatus([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling UpdateBrandStatus function");

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

            if (request.Status == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _franchiseService.UpdateBrandStatus(request.Id.Value, Enum.Parse<Status>(request.Status.Value.ToString()), loggedInUser.FranchiseId.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(UpdateFranchiseStatus))]
        public async Task<HttpResponseData> UpdateFranchiseStatus([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling UpdateFranchiseStatus function");

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

            if (request.Status == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _franchiseService.UpdateFranchiseStatus(request.Id.Value, Enum.Parse<Status>(request.Status.Value.ToString()), loggedInUser.FranchiseId.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }


    }
}
