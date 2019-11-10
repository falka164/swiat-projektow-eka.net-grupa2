using System;
using System.Collections.Generic;
using System.Text;

namespace Meetapp.Core.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        // UserId
        // SenderId
    }
}
