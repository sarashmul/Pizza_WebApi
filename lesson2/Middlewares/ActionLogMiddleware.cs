
using MyFileServiceLib;
using MyFileServiceLib.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;

namespace lesson2.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ActionLogMiddleware
    {
        private readonly RequestDelegate _next;
        private IFileService<string> _file;
        private string _path=@"H:\webapi\lesson8\WebApi\lesson2\actionLog.txt";
        public ActionLogMiddleware(RequestDelegate next, IFileService<string> file)
        {
            _next = next;
            _file= file;
        }

        public Task Invoke(HttpContext httpContext)
        {
             
             _file.Write("the time: "+DateTime.UtcNow.ToString(),_path);
             _file.Write("the header: "+httpContext.Request.Headers.ToString(),_path);
             _file.Write("the body: "+httpContext.Request.Body.ToString(),_path);
             _file.Write("the Httpmethod"+httpContext.Request.Method.ToString(),_path);

         
            var task=_next(httpContext);
             _file.Write("the time: "+DateTime.UtcNow.ToString(),_path);
             _file.Write("the statuscode: "+httpContext.Response.StatusCode.ToString(),_path);
           
            
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ActionLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseractionLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ActionLogMiddleware>();
        }
    }
}
