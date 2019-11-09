using System;
using System.Collections.Generic;
using System.Text;

namespace Meetapp.Core.Responses
{
    /// <summary>
    /// Class used as authorizaction failed response with errors list/array
    /// Author: Blonski
    /// </summary>
    class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
