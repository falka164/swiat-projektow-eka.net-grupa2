using System;
using System.Collections.Generic;
using System.Text;
using Meetapp.Core.Entities.User;

namespace Meetapp.Core.Entities
{
    public class UserEvent
    {
        public int Id { get; set; }
        // UserId
        public string UserRole { get; set; }
        public Event Event { get; set; }
        public User.User User { get; set; }
       
    }
}
