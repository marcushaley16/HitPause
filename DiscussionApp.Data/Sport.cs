using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Data
{
    public enum League
    {
        Bundesliga,
        PremierLeague,
        LaLiga,
        MensTennis,
        MLB,
        MLS,
        NBA,
        NCAABasketball,
        NCAAFootball,
        NFL,
        NHL,
        None,
        Other,
        SerieA,
        UEFAChampionsLeague,
        WNBA,
        WomensTennis
    }

    public class Sport
    {
        [Key]
        public int SportId { get; set; }
        [Required]
        public MediaType MediaType { get; set; }
        [Required]
        public League League { get; set; }
        [Required]
        public string HomeTeam { get; set; }
        [Required]
        public string AwayTeam { get; set; }
        public string Matchup { get => $"{AwayTeam} @ {HomeTeam}"; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public string Network { get; set; }
        public string Score { get; set; }
    }
}
