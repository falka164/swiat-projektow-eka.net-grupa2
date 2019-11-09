using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Meetapp.Services.Interfaces;
using Meetapp.Core.Responses;

namespace Meetapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {
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