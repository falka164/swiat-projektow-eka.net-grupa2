
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meetapp.Core.Entities.User
{
    public class User : IdentityUser
    {
     public ICollection<UserEvent> UserEvents { get; set; }

    }
}
