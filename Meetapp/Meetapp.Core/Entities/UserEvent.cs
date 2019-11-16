using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Meetapp.Core.Entities.User;

namespace Meetapp.Core.Entities
{
    public class UserEvent
    {
        [Required]
        public int Id { get; set; }
        // UserId
        [Required]
        public string UserRole { get; set; }
        [ForeignKey("EventFK")]
        public Event Event { get; set; }
        public int EventFK { get; set; }
        [ForeignKey("UserFK")]
        public User.User User { get; set; }
        public string UserFK { get; set; }

    }
}
