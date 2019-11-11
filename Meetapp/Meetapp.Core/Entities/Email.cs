using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meetapp.Core.Entities
{
    public class Email
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Subject { get; set; }
        [MaxLength(1000)]
        public string Message { get; set; }
        // UserId
        // SenderId
    }
}
