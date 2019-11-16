using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meetapp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class QueryTestController : Controller
    {
        [HttpPost("Test2")]
        [Authorize]
        public IActionResult TestAuth()
        {
            return Ok();
        }
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}