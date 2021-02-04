using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class EventTag
    {
        public DbSet<EventTag> EventTags { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public EventTag()
        {
        }

    }
}
