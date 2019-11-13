using System;
using System.Collections.Generic;
using System.Text;

namespace Meetapp.Core.Responses
{
    ///<summary>
    ///Class used as Succesful response to authorizacion mechanism
    ///Author:Blonski
    ///</summary>
    public class AuthSuccesResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
