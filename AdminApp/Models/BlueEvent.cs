using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    class BlueEvent
    {
        public BlueEvent()
        {
            Judge = new HashSet<Judge>();
            Team = new HashSet<Team>();
        }

        public int Eventid { get; set; }
        public DateTime? Eventdate { get; set; }
        public DateTime? Deadline { get; set; }

        public ICollection<Judge> Judge { get; set; }
        public ICollection<Team> Team { get; set; }
    }
}
