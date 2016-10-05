using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playscape.Models.Requests
{
    public class EventsUpdateRequest
    {
        public int Id { get; set; }

        public int EventType { get; set; }

        public bool IsPublic { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public int Duration { get; set; }

        public int MediaId { get; set; }

        public int NumberAttendees { get; set; }

    }
}
