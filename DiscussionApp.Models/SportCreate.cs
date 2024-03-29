﻿using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class SportCreate
    {
        //[Required]
        public MediaType MediaType { get; set; }
        [Required]
        public League League { get; set; }
        [Required]
        public string HomeTeam { get; set; }
        [Required]
        public string AwayTeam { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public string Network { get; set; }
        public string Score { get; set; }
    }
}
