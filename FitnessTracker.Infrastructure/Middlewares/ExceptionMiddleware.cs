using FitnessTracker.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace FitnessTracker.Infra.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var message = exception.InnerException?.Message ?? exception.Message;

            ProblemDetails problemDetails = exception switch
            {
                BadRequestException => new()
                {
                    Detail = message,
                    Status = StatusCodes.Status400BadRequest
                },
                NotFoundException => new()
                {
                    Detail = message,
                    Status = StatusCodes.Status404NotFound
                },
                DbUpdateException => new()
                {
                    Detail = message,
                    Status = StatusCodes.Status409Conflict
                },
                _ => new()
                {
                    Detail = message,
                    Status = StatusCodes.Status500InternalServerError
                }
            };

            context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}