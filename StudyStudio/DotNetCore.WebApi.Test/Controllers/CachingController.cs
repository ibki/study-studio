using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.WebApi.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CachingController : ControllerBase
    {
        [HttpGet("{template}")]
        [ResponseCache(Duration = 15)] // 15 sec
        public async Task<IActionResult> Get()
        {
            await Task.Delay(1000);

            var route = Request.RouteValues;

            var action = route["action"];
            var controller = route["controller"];
            var template = route["template"];

            return Ok($"{nameof(action)}: {action}, " +
                $"{nameof(controller)}: {controller}, " +
                $"{nameof(template)}: {template}");
        }
    }
}
