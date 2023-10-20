using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingApp.Models
{
    public class PastUpcomingEventsDTO
    {
        public IList<Event> PastEvents { get; set; }
        public IList<Event> UpcomingEvents { get; set; }
    }
}
