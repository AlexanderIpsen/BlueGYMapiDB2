using System;
using System.Collections.Generic;

namespace BlueGYMapiDB2.Models
{
    public partial class Judge
    {
        public int Judgeid { get; set; }
        public string Judgename { get; set; }
        public string Judgeemail { get; set; }
        public string Judgepaas { get; set; }
        public int? Eventid { get; set; }

        public BlueEvent Event { get; set; }
    }
}
