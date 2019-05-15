using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class TVShowCreate
    {
        [Required]
        public MediaType MediaType { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Network { get; set; }
        [Required]
        public TVGenreType Genre1 { get; set; }
        public TVGenreType Genre2 { get; set; }
        [Required]
        [MaxLength(5, ErrorMessage = "Please enter a valid rating.")]
        public string Rating { get; set; }
        [Required]
        public int Runtime { get; set; }
        [Required]
        public string Synopsis { get; set; }
        [Required]
        public string Creator { get; set; }
        [Required]
        public string Stars { get; set; }
        [Required]
        public bool Released { get; set; }
        //public string DateAired { get; set; }
        //public string Director { get; set; }
        //public string Writer { get; set; }
        //public string Cinematographer { get; set; }
        //public string Editor { get; set; }
    }
}
