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
        public int DiscussionId { get; set; }
        public int FilmId { get; set; }
        public int TelevisionId { get; set; }
        public int SportId { get; set; }
        [Display(Name = "Type")]
        public MediaType MediaType { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedUtc {get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string Comment { get; set; }
        public virtual Film Film { get; set; }
        public virtual TVShow TVShow { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
