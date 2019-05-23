using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class DiscussionDetail
    {
        [Display(Name = "ID")]
        public Guid DiscussionId { get; set; }
        [Display(Name = "Type")]
        public MediaType MediaType { get; set; }
        public int FilmId { get; set; }
        public int TelevisionId { get; set; }
        public int SportId { get; set; }
        public string DiscussionTitle { get; set; }
        public Guid? CreatorId { get; set; }
        public string CreatorUsername { get; set; }
        public DateTimeOffset CreatedUTC {get; set; }
        //public DateTimeOffset? ModifiedUtc { get; set; }
        public int PostCount { get; set; }
        public virtual Film Film { get; set; }
        public virtual TVShow TVShow { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
