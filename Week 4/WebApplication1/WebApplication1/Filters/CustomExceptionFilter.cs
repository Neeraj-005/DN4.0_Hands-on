using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace WebApplication1.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // The logging part remains the same
            string exceptionMessage = $"[Timestamp: {System.DateTime.Now}]" +
                                      $"\nException Type: {context.Exception.GetType().Name}" +
                                      $"\nMessage: {context.Exception.Message}" +
                                      $"\nStackTrace: {context.Exception.StackTrace}\n\n";

            File.AppendAllText("exception_log.txt", exceptionMessage);

            // This is the MODERN way to set the response in .NET 8
            var errorResponse = new { message = "An unexpected error occurred.", detail = context.Exception.Message };
            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = 500 // Internal Server Error
            };

            context.ExceptionHandled = true;
        }
    }
}