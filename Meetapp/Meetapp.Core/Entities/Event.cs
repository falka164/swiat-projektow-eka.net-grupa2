using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Meetapp.Core.Entities
{

    public class Event
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [MaxLength(25)]
        public string Location { get; set; }
        [MaxLength(25)]
        public string Category { get; set; }
        [Required]
        public DateTime SaleExpDate { get; set; }
        public Boolean ReqConfirm { get; set; }
        //[ForeignKey("EventFK")]
        public ICollection<UserEvent> userEvents { get; set; }

    }
}
