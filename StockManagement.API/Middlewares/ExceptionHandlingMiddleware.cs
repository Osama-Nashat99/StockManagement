
using Microsoft.AspNetCore.Mvc;
using StockManagement.Domain.Exceptions;
using System.Net;

namespace StockManagement.API.Middlewares
{
    public class ExceptionHandlingMiddleware: IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BadRequestException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await HandleExceptionAsync(context, ex);
            }
            catch (UnAuthorizedException ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await HandleExceptionAsync(context, ex);
            }
            catch (ForbiddenException ex)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await HandleExceptionAsync(context, ex);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            
            var traceId = Guid.NewGuid();
            _logger.LogError(
                "Error occurred while processing the request. TraceId: {TraceId}, Message: {Message}, StackTrace: {StackTrace}",
                traceId, exception.Message, exception.StackTrace
            );

            var problemDetails = new CustomProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError.GetHashCode(),
                Instance = context.Request.Path,
                Detail = $"Internal server error occured, traceId : {traceId}",
                ExceptionMessage = exception.Message
            };
            return context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
