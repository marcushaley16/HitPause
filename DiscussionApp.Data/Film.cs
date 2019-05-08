using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Data
{
    public enum FilmGenreType
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
        History,
        Horror,
        Music,
        Musical,
        Mystery,
        Noir,
        Other,
        Romance,
        SciFi,
        Short,
        Thriller,
        War,
        Western
    }

    public class Film
    {
        [Key]
        public int FilmId { get; set; }
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
        public string Cinematographer { get; set; }
        [Required]
        public string Editor { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "The synopsis is limited to 150 characters.")]
        public string Synopsis { get; set; }
        [Required]
        public FilmGenreType Genre { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "Please enter a valid year.")]
        public string Year { get; set; }
        [Required]
        public bool Released { get; set; }
        [Required]
        public int Runtime { get; set; }
        [Required]
        [MaxLength(5, ErrorMessage = "Please enter a valid rating.")]
        public string Rating { get; set; }
        public string Quote { get; set; }
    }
}
