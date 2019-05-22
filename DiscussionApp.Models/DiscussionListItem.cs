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
        public Guid DiscussionId { get; set; }

        public int FilmId { get; set; }
        public int TelevisionId { get; set; }
        //public int SportId { get; set; }
        public string FilmTitle { get; set; }

        [Display(Name = "Type")]
        public MediaType MediaType { get; set; }

        [Display(Name = "Title")]
        public string DiscussionTitle { get; set; }

        public Guid CreatorId { get; set; } // hidden

        public string CreatorUsername { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Posts")]
        public int? PostCount { get; set; }

        public string LastPostCreatorUsername { get; set; }

        [Display(Name = "Last Post")]
        public DateTimeOffset? LastPostUTC { get; set; }

        public override string ToString() { return base.ToString(); }
    }
}
