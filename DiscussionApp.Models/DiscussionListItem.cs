using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class DiscussionListItem
    {
        [Display(Name = "ID")]
        public int DiscussionId { get; set; }

        public int FilmId { get; set; }
        //public int TelevisionId { get; set; }
        //public int SportId { get; set; }

        [Display(Name="Type")]
        public MediaType MediaType { get; set; }

        public string DiscussionTitle { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Last Post")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
