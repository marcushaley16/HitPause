using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class SportDetail
    {
        [Display(Name = "ID")]
        public int SportId { get; set; }
        [Display(Name = "Type")]
        public MediaType MediaType { get; set; }
        public League League { get; set; }
        [Display(Name = "Home")]
        public string HomeTeam { get; set; }
        [Display(Name = "Away")]
        public string AwayTeam { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public string Network { get; set; }
        public string Score { get; set; }
    }
}
