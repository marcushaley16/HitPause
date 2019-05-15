using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class SportEdit
    {
        public int SportId { get; set; }
        public MediaType MediaType { get; set; }
        public League League { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public string Network { get; set; }
        public string Score { get; set; }
    }
}
