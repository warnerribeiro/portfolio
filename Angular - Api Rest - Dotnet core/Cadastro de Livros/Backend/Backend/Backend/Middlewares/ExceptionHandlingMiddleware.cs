using Domain.Response;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Web.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            var errorResponse = new ErrorResponse
            {
                Success = false
            };

            switch (exception)
            {
                case SqlException:
                case DbUpdateException:
                    response.StatusCode =
                        errorResponse.StatusCode = StatusCodes.Status500InternalServerError;
                    errorResponse.Message = "Error ao Persistir no banco de dados.";
                    break;
                default:
                    response.StatusCode =
                        errorResponse.StatusCode = StatusCodes.Status500InternalServerError;
                    errorResponse.Message = "Error interno no servidor, verifique os logs.";
                    break;
            }

            _logger.LogError(exception?.InnerException?.Message ?? exception?.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
    }
}
