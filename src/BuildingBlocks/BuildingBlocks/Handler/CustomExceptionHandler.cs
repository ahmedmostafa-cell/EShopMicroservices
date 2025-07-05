using BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FluentValidation;
using System.Text.Json;
namespace BuildingBlocks.Handler
{
    public class CustomExceptionHandler
        (ILogger<CustomExceptionHandler> logger)
        : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, 
            CancellationToken cancellationToken)
        {
            logger.LogError("Error Message : {errorMessage} , Time Of Occurence : {timeMessage}"
                ,exception.Message , DateTime.UtcNow);

            (string Detail, string Title, int StatusCode) details = exception switch
            {
                InternalServerException => 
                (
                    exception.Message,
                    exception.GetType().Name, 
                    StatusCodes.Status500InternalServerError
                ),

                ValidationException =>
               (
                   exception.Message,
                   exception.GetType().Name,
                   StatusCodes.Status400BadRequest
               ),

                BadRequestException =>
              (
                  exception.Message,
                  exception.GetType().Name,
                  StatusCodes.Status400BadRequest
              ),

                NotFoundException =>
              (
                  exception.Message,
                  exception.GetType().Name,
                  StatusCodes.Status404NotFound
              ),

                _ =>
              (
                  exception.Message,
                  exception.GetType().Name,
                  StatusCodes.Status500InternalServerError

              )


            };

            var problemDetails = new ProblemDetails
            {
                Title = details.Title,
                Detail = details.Detail,
                Status = details.StatusCode,
                Instance = context.Request.Path
            };

            problemDetails.Extensions.Add("traceId", context.TraceIdentifier);

            if(exception is ValidationException validationException) 
            {
                problemDetails.Extensions.Add("errors", validationException.Errors);
            }

            await context.Response.WriteAsJsonAsync(problemDetails,
                new JsonSerializerOptions(),
                "application/problem+json", cancellationToken);

            return true;
        }
    }
}
