using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Data
{
    public enum TVGenreType
    {
        Action = 1,
        Adventure,
        Animation,
        Biography,
        Comedy,
        Crime,
        Documentary,
        Drama,
        Family,
        Fantasy,
        GameShow,
        History,
        Horror,
        Music,
        Musical,
        Mystery,
        News,
        Noir,
        None,
        Reality,
        Romance,
        SciFi,
        Short,
        Sport,
        TalkShow,
        Thriller,
        War,
        Western
    }

    public class TVShow
    {
        [Key]
        public int TelevisionId { get; set; }
        [Required]
        public MediaType MediaType { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Creator { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        [Required]
        public string Stars { get; set; }
        [Required]
        public string Synopsis { get; set; }
        [Required]
        public TVGenreType Genre1 { get; set; }
        public TVGenreType Genre2 { get; set; }
        [Required]
        public string Network { get; set; }
        [Required]
        public bool Released { get; set; }
        [Required]
        public string Year { get; set; }
        public string DateAired { get; set; }
        [Required]
        public int Runtime { get; set; }
        [Required]
        public string Rating { get; set; }
        public string Cinematographer { get; set; }
        public string Editor { get; set; }
    }
}
