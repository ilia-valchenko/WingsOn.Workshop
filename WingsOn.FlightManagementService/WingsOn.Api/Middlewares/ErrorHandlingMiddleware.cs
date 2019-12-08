using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WingsOn.Core.Exceptions;

namespace WingsOn.Api.Middlewares
{
    /// <summary>
    /// The error handling middleware.
    /// </summary>
    public sealed class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHandlingMiddleware"/> class.
        /// </summary>
        /// <param name="next">A function that can process an HTTP request.</param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the next middleware.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        /// Returns an instance of the <see cref="Task"/> class.
        /// </returns>
        public async Task Invoke(HttpContext context)
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

        /// <summary>
        /// Handles an exception async.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="ex">The exception.</param>
        /// <returns>
        /// Returns an instance of the <see cref="Task"/> class.
        /// </returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            if (ex is ResourceNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            } else if (ex is ResourceAlreadyExistException)
            {
                code = HttpStatusCode.Conflict;
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}