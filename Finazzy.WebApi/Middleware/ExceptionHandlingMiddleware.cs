﻿using System.Text.Json;
using Finazzy.Application.Exceptions;
using Finazzy.Domain.Exceptions.Base;

namespace Finazzy.WebApi.Middleware;

public sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, ex.Message);

			await HandleExceptionAsync(context, ex);
		}
    }

	private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
	{
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = exception switch
        {
            BadRequestException or ValidationException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            NotMatchedException => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        var errors = Array.Empty<ApiError>();

        if (exception is ValidationException validationException)
        {
            errors = validationException.Errors
                .SelectMany(
                    kvp => kvp.Value,
                    (kvp, value) => new ApiError(kvp.Key, value))
                .ToArray();
        }

        var response = new
        {
            status = httpContext.Response.StatusCode,
            message = exception.Message,
            errors
        };

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private record ApiError(string PropertyName, string ErrorMessage);
}
