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
                return BadRequest(new AuthorizationResult
                {
                    Errors = new string[]{"Wrong parameters"}
                });
            }
            var response = await _userService.RegisterAsync(email, password);
            if(!response.Succes) //failed to create User
            {
                return BadRequest(new AuthorizationResult
                { 
                Errors = response.Errors
                });
            }
            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (email == null || password == null) //Temporary?
            {
                return BadRequest(new AuthorizationResult
                {
                    Errors = new string[] { "Wrong parameters" }
                });
            }
            var response = await _userService.LoginAsync(email, password);
            if (!response.Succes) //failed to create User
            {
                return BadRequest(new AuthorizationResult
                {
                    Errors = response.Errors
                });
            }
            return Ok(response);
        }
    }
}