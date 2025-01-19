using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lesson2.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsControllers : Controller
    {
        private readonly ILogger<ErrorsControllers> _logger;

        public ErrorsControllers(ILogger<ErrorsControllers> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/error")]
        public ActionResult Error([FromServices] IHostEnvironment hostEnvironment)
        {
            var exceptionHandlerFeature =
           HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.LogError(exceptionHandlerFeature?.Error.ToString());
            return Problem(
                detail: "Please try later...",
                title: "Sorry...");
        }
        [Route("/error-development")]
        public ActionResult DevelopmentError([FromServices] IHostEnvironment
      hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return Error(hostEnvironment);
            }
            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.LogError(exceptionHandlerFeature?.Error.ToString());
            return Problem(
                detail: exceptionHandlerFeature?.Error.StackTrace,
                title: exceptionHandlerFeature?.Error.Message);
        }
    }
}