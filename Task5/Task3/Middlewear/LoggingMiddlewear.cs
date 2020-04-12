using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Task3.DAL;

namespace Task3.Middlewear
{
    public class LoggingMiddlewear
    { 
        private readonly RequestDelegate _next;

        public LoggingMiddlewear(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, IDbService dbService)
        {
            if (httpContext.Request != null)
            {
                var method = httpContext.Request.Method;
                var path = httpContext.Request.Path;
                string body = "";
                var queryString = httpContext.Request.QueryString;

                using (var reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true) )
                {
                    body = await reader.ReadToEndAsync();
                }

                string data =
                    $"[\n Method: {method}\n Endpoint: {path}\n Body: {body}\n Query strings: {queryString}\n]";
                dbService.saveLogData(data);
            }
            await _next(httpContext);
        }
    }
}