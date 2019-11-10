using System;
using System.Collections.Generic;
using System.Text;

namespace Meetapp.Core.Entities
{

    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public DateTime SaleExpDate { get; set; }
        public Boolean ReqConfirm { get; set; }
        public ICollection<UserEvent> userEvents { get; set; }

    }
}
