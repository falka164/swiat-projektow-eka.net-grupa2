using Meetapp.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meetapp.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthorizationResult> RegisterAsync(string email, string password);

        Task<AuthorizationResult> LoginAsync(string email, string password);
    }
}
