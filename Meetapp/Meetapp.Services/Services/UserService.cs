using Meetapp.Core;
using Meetapp.Core.Entities.User;
using Meetapp.Core.Responses;
using Meetapp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Meetapp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<AuthorizationResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return new AuthorizationResult
                {
                    Errors = new[] { "Brak użytkownika" }
                };
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if(!userHasValidPassword)
            {
                return new AuthorizationResult
                {
                    Errors = new[] { "Wrong Password" }
                };
            }

            return await GenerateAuthenticationResultAsync(user);

        }
        private async Task<AuthorizationResult> GenerateAuthenticationResultAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("eKaeKaeKaeKaeKaeKaeKaeKaeKaeKaeKaeKaeKaeKaeKa");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("id", user.Id)
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach(var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role == null) continue;
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach( var roleClaim in roleClaims)
                {
                    if(claims.Contains(roleClaim)) continue;
                    claims.Add(roleClaim);
                }
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(new TimeSpan(1, 0, 0, 0)), //one day
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthorizationResult
            {
                Succes = true,
                Token = tokenHandler.WriteToken(token)
            };

        }
        public async Task<AuthorizationResult> RegisterAsync(string email, string password)
        {
            //Check if User Exist
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null) //if exist
            {
                return new AuthorizationResult
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
                return new AuthorizationResult
                {
                    Succes = false,
                    Errors = createdUser.Errors.Select(error => error.Description)
                };
            };
            return await GenerateAuthenticationResultAsync(newUser);

        }
    }
}

