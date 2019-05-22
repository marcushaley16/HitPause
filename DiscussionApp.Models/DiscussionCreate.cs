using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class DiscussionCreate
    {
        public Guid DiscussionId { get; set; }
        [Required]
        public MediaType MediaType { get; set; }
        public int FilmId { get; set; }
        public int TelevisionId { get; set; }
        public int SportId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Titles must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "Titles are limited to 50 characters.")]
        public string DiscussionTitle { get; set; }
        public string Body { get; set; }
        public virtual Film Film { get; set; }
        //public virtual TVShow TVShow { get; set; }
        //public virtual Sport Sport { get; set; }
        public override string ToString() => DiscussionTitle;
    }
}
