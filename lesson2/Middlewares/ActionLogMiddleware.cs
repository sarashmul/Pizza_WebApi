
// using MyFileServiceLib;
// using MyFileServiceLib.Interface;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Http;
// using System.Globalization;
// using System.Threading.Tasks;

// namespace lesson2.Middlewares
// {
//     // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
//     public class ActionLogMiddleware
//     {
//         private readonly RequestDelegate _next;
//         private IFileService<string> _file;
//         private string _path=@"H:\webapi\lesson7\WebApi\lesson2\actionLog.txt";
//         public ActionLogMiddleware(RequestDelegate next, IFileService<string> file)
//         {
//             _next = next;
//             _file= file;
//         }

//         public Task Invoke(HttpContext httpContext)
//         {
             
//              _file.Write("the time: "+DateTime.UtcNow.ToString(),_path);
//              _file.Write("the header: "+httpContext.Request.Headers.ToString(),_path);
//              _file.Write("the body: "+httpContext.Request.Body.ToString(),_path);
//              _file.Write("the Httpmethod"+httpContext.Request.Method.ToString(),_path);

         
//             var task=_next(httpContext);
//              _file.Write("the time: "+DateTime.UtcNow.ToString(),_path);
//              _file.Write("the statuscode: "+httpContext.Response.StatusCode.ToString(),_path);
           
            
//             return _next(httpContext);
//         }
//     }

//     // Extension method used to add the middleware to the HTTP request pipeline.
//     public static class ActionLogMiddlewareExtensions
//     {
//         public static IApplicationBuilder UseractionLog(this IApplicationBuilder builder)
//         {
//             return builder.UseMiddleware<ActionLogMiddleware>();
//         }
//     }
// }


using MyFileServiceLib;
using MyFileServiceLib.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace lesson2.Middlewares
{
    public class ActionLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IFileService<string> _file;
        private readonly string _path = Path.Combine(AppContext.BaseDirectory, "App_Data", "actionLog.txt");

        public ActionLogMiddleware(RequestDelegate next, IFileService<string> file)
        {
            _next = next;
            _file = file;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            _file.Write("========== REQUEST ==========");
            _file.Write("Time: " + DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            _file.Write("Method: " + request.Method);
            _file.Write("Headers: " + request.Headers.ToString());

            // Read body safely
            request.EnableBuffering(); // Allows rereading
            request.Body.Position = 0;
            using (var reader = new StreamReader(request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true))
            {
                var bodyStr = await reader.ReadToEndAsync();
                _file.Write("Body: " + bodyStr);
            }
            request.Body.Position = 0; // Reset stream position

            await _next(context);

            // After response
            _file.Write("========== RESPONSE ==========");
            _file.Write("Time: " + DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            _file.Write("Status Code: " + context.Response.StatusCode.ToString());
        }
    }

    public static class ActionLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseActionLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ActionLogMiddleware>();
        }
    }
}
