﻿using FoodsNow.Core.Dto;
using FoodsNow.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
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

            var request = JsonConvert.DeserializeObject<CustomerDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.ContactNumber))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _customerService.AddCustomer(request);

            var response = req.CreateResponse(HttpStatusCode.OK);
            if (data == null)
            {
                await response.WriteAsJsonAsync(new { isSuccess = false, ErrorMessage = "Customer with this detail already exist" });
            }
            else
            {
                await response.WriteAsJsonAsync(new { isSuccess = true, data });

            }

            return response;
        }

        [Function(nameof(VerifyPin))]
        public async Task<HttpResponseData> VerifyPin([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Register funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CustomerDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.VerificationCode))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Id == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _customerService.VerifyPin(request.VerificationCode, request.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(new { isSuccess = data, ErrorMessage = data ? "" : "Verification failed" });

            return response;
        }

        [Function(nameof(CustomerLogin))]
        public async Task<HttpResponseData> CustomerLogin([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Register funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CustomerDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.EmailAdress))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.Password))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _customerService.CustomerLogin(request);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(new { isSuccess = data, ErrorMessage = data ? "" : "Login failed" });

            return response;
        }

        [Function(nameof(CustomerAddAddress))]
        public async Task<HttpResponseData> CustomerAddAddress([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Register funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CustomerAddressDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _customerService.AddAddress(request);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(new { isSuccess = data != null, ErrorMessage = data != null ?  "" : "Adding address failed" });

            return response;
        }

        [Function(nameof(CustomerUpdateAddress))]
        public async Task<HttpResponseData> CustomerUpdateAddress([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Register funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CustomerAddressDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _customerService.UpdateAddress(request);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(new { isSuccess = data != null, ErrorMessage = data != null ? "" : "Updating address failed" });

            return response;
        }
    }
}