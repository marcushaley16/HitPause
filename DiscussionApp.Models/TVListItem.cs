using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Models
{
    public class TVShowListItem
    {
        [Display(Name = "ID")]
        public int TelevisionId { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Stars { get; set; }
        [Display(Name = "Genre")]
        public TVGenreType Genre1 { get; set; }
        public TVGenreType Genre2 { get; set; }
        public string Network { get; set; }
        public string Year { get; set; }
    }
}
