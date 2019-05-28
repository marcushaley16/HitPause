using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class SportListItem
    {
        [Display(Name = "ID")]
        public int SportId { get; set; }
        public League League { get; set; }
        [Display(Name = "Home")]
        public string HomeTeam { get; set; }
        [Display(Name = "Away")]
        public string AwayTeam { get; set; }
        public string Matchup { get => $"{AwayTeam} @ {HomeTeam}"; }
        public string Location { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyy} at {0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }
        public string Network { get; set; }
        public string Score { get; set; }
    }
}
