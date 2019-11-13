using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Meetapp.Services.Interfaces;
using Meetapp.Core.Responses;

namespace Meetapp.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(string email, string password)
        {
            if(email==null ||  password==null) //Temporary?
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = new string[]{"Wrong parameters"}
                });
            }
            var response = await _userService.RegisterAsync(email, password);
            if(!response.Succes) //failed to create User
            {
                return BadRequest(new AuthFailedResponse
                { 
                Errors = response.Errors
                });
            }
            return Ok(new AuthSuccesResponse{});
        }
    }
}