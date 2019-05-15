using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Data
{
    public enum MediaType
    {
        Film = 1,
        Television,
        Sports
    }

    public class Discussion
    {
        [Key]
        public int DiscussionId { get; set; }
        public int FilmId { get; set; }
        //public int TelevisionId { get; set; }
        //public int SportId { get; set; }
        public MediaType MediaType { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Titles must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "Titles are limited to 50 characters.")]
        public string Title { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string Comment { get; set; }
        public virtual Film Film { get; set; }
        //public virtual TVShow TVShow { get; set; }
        //public virtual Sport Sport { get; set; }
    }
}
