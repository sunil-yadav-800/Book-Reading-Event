using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingApp.Models
{
    public class EventViewModel
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Others { get; set; }
        public int TotalInvited { get; set; }
        public IList<Comment> PastComments { get; set; }
        public int EventId { get; set; } //needed for comments
    }
}
