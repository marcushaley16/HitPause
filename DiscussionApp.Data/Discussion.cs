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
        [Required]
        [MinLength(5, ErrorMessage = "Titles must be at least 5 characters long.")]
        [MaxLength(30, ErrorMessage = "Titles are limited to 30 characters.")]
        public string Title { get; set; }
        [Required]
        public DateTime TimeCreated { get; set; }
        [Required]
        public MediaType MediaType { get; set; }
        //[Required]
        //public int MediaId { get; set; }
        public string Comment { get; set; }
    }
}
