using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Shared.ErrorModels;
using System.Net;
using System.Threading.Tasks;

namespace E_Commerce.Web.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, 
            ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {

                await _next.Invoke(httpContext);

                await HandleNotFoundEndPointAsync(httpContext);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            // Set Status Code for the response
            //        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Set Content Type for the response
            httpContext.Response.ContentType = "application/json";

            // Response Object
            var response = new ErrorDetails
            {
                //StatusCode = (int)HttpStatusCode.InternalServerError,
                ErrorMessage = ex.Message
            };


            response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError,
            };
            // Return response as JSON
            httpContext.Response.StatusCode = response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(response);
        }

        private static async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                httpContext.Response.ContentType = "application/json";

                var response = new ErrorDetails
                {
                    ErrorMessage = $"End Point {httpContext.Request.Path} Not Found",
                    StatusCode = (int)HttpStatusCode.NotFound
                };

                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }

    
}