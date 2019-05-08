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

    public class Television
    {
        [Key]
        public int TelevisionId { get; set; }
        [Required]
        public MediaType MediaType { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Writer { get; set; }
        [Required]
        public string Stars { get; set; }
        [Required]
        public string Synopsis { get; set; }
        [Required]
        public TVGenreType Genre { get; set; }
        [Required]
        public string Network { get; set; }
        [Required]
        public string DateAired { get; set; }
        [Required]
        public int Runtime { get; set; }
        [Required]
        public string Rating { get; set; }
        public string Creator { get; set; }
        public string Cinematographer { get; set; }
        public string Editor { get; set; }
        public string Quote { get; set; }

    }
}
