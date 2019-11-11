
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Meetapp.Core.Entities.User
{
    public class User : IdentityUser
    {

     //[ForeignKey("UserFK")]
     public ICollection<UserEvent> UserEvents { get; set; }

    }
}
