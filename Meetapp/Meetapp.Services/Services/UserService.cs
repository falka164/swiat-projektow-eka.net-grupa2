using Meetapp.Core.Entities.User;
using Meetapp.Core.Responses;
using Meetapp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Meetapp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;              
        }
        public async Task<AuthorizationResponse> RegisterAsync(string email, string password)
        {
            //Check if User Exist
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null) //if exist
            {
                return new AuthorizationResponse
                {
                    Succes = false,
                    Errors = new[] { "TO DO MESSAGE - user with this mail exists" }
                };

            }
            var newUser = new User
            {
                Email = email,
                UserName = email //Probably temporary. We don't know if mail will be a login
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);
            if (!createdUser.Succeeded)
            {
                return new AuthorizationResponse
                {
                    Succes = false,
                    Errors = createdUser.Errors.Select(error => error.Description)
                };
            };
            return new AuthorizationResponse
            {
                Succes = true
            };

        }
    }
}

