using FluentValidation;
using LibrarySystem.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Exceptions
{
    public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService ) : IExceptionHandler
    {
        //public object StatusCode { get; private set; }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails problem = exception switch
            {
                ValidationException ex => new ValidationProblemDetails
                (
                    ex.Errors.GroupBy(g => g.PropertyName)
                    .ToDictionary
                    (
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    )
                )
                {
                    Title = "Validation failed",
                    Status = StatusCodes.Status400BadRequest
                },

                NotFoundException ex => new ProblemDetails
                {
                    Title = "Resource Not Found!",
                    Detail = exception.Message,
                    Status = StatusCodes.Status404NotFound
                },


                InvalidOperationException ex => new ProblemDetails
                {
                    Title = "Business Rule Violation",
                    Detail = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                },

                //anything else 
                _ => new ProblemDetails
                {
                    Title = "Server Error!",
                    Detail = "An unhandled exception",
                    Status = StatusCodes.Status500InternalServerError
                }


            };

            httpContext.Response.StatusCode = problem.Status!.Value;

            await problemDetailsService.WriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                ProblemDetails = problem

            });

            return true;


        }
    }
}
