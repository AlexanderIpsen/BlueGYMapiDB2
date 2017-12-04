using System;
using System.Collections.Generic;

namespace BlueGYMapiDB2.Models
{
    public partial class Team
    {
        public int Teamid { get; set; }
        public string Teamname { get; set; }
        public string Teamtrack { get; set; }
        public string Teamemail { get; set; }
        public string Teampaas { get; set; }
        public string Teamreport { get; set; }
        public string Teamquestionpoints { get; set; }
        public string Teamreportpoints { get; set; }
        public int? Eventid { get; set; }

        public BlueEvent Event { get; set; }
    }
}
