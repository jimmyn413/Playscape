using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playscape.Models
{
   public class EventsRequest
    {   
        [Required]
        public string UserId { get; set; }
        [Required]
        public int EventType { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public int Duration { get; set; }

        public int MediaId { get; set; }
        [Required]
        public int NumberAttendees { get; set; }

    }
}
