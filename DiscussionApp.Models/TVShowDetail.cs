using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class TVShowDetail
    {
        [Display(Name="ID")]
        public int TelevisionId { get; set; }
        [Display(Name="Type")]
        public MediaType MediaType { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Synopsis { get; set; }
        public string Stars { get; set; }
        [Display(Name = "Genre")]
        public TVGenreType Genre1 { get; set; }
        public TVGenreType Genre2 { get; set; }
        public string Network { get; set; }
        public bool Released { get; set; }
        public string Year { get; set; }
        public string DateAired { get; set; }
        public int Runtime { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Cinematographer { get; set; }
        public string Editor { get; set; }
    }
}
