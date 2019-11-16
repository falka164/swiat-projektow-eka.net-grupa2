using System;
using System.Collections.Generic;
using System.Text;

namespace Meetapp.Core.Responses
{
    public class AuthorizationResult
    {
        public bool Succes { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
