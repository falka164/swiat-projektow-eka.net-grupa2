using System;
using System.Collections.Generic;
using System.Text;

namespace Meetapp.Core.Responses
{
    public class AuthorizationResponse
    {
        public bool Succes { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
