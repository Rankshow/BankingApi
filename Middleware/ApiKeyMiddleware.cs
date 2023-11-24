using System.Net;
using BankingApi.Interfaces;
using Newtonsoft.Json;

namespace BankingApi.Middleware
{
    public class ApiKeyMiddleware : IMiddleware
    {
        private readonly IApiKeyValidationService _apiKeyValidationService;
        public ApiKeyMiddleware(IApiKeyValidationService apiKeyValidationService)
        {
            _apiKeyValidationService = apiKeyValidationService;
        }
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var headerKey = context.Request.Headers[Constant.AppConstant.ApiKeyHeaderName].ToString();

            if(!_apiKeyValidationService.IsValidApiKey(headerKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var message = new { meassage = "Api key is not found or Invalid"};
                context.Response.WriteAsync(new (JsonConvert.SerializeObject(message)));
                return Task.CompletedTask;
            }
            next(context);
            return Task.CompletedTask;
        }
    }
}