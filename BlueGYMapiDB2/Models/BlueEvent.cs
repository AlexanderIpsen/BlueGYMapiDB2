using System;
using System.Collections.Generic;

namespace BlueGYMapiDB2.Models
{
    public partial class BlueEvent
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
