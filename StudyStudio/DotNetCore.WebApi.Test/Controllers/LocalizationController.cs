using DotNetCore.WebApi.Test.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.WebApi.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        [HttpGet("hello-world")]
        public IActionResult HelloWorld()
        {
            return Ok(Resource.HelloWorld);
        }
    }
}
