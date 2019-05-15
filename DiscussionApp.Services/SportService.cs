using DiscussionApp.Data;
using DiscussionApp.Models;
using DiscussionApp.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionApp.Services
{
    public class SportService
    {
        public bool CreateSport(SportCreate model)
        {
            var entity =
                new Sport()
                {
                    MediaType = model.MediaType,
                    League = model.League,
                    HomeTeam = model.HomeTeam,
                    AwayTeam = model.AwayTeam,
                    Location = model.Location,
                    Time = model.Time,
                    Network = model.Network,
                    Score = model.Score
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sports.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SportListItem> GetSports()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sports
                        .Select(
                            e =>
                                new SportListItem
                                {
                                    SportId = e.SportId,
                                    League = e.League,
                                    HomeTeam = e.HomeTeam,
                                    AwayTeam = e.AwayTeam,
                                    Location = e.Location,
                                    Time = e.Time,
                                    Network = e.Network,
                                    Score = e.Score
                                }
                        );

                return query.ToArray();
            }
        }

        public SportDetail GetSportById(int sportId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sports
                        .Single(e => e.SportId == sportId);
                return
                    new SportDetail
                    {
                        SportId = entity.SportId,
                        League = entity.League,
                        HomeTeam = entity.HomeTeam,
                        AwayTeam = entity.AwayTeam,
                        Location = entity.Location,
                        Time = entity.Time,
                        Network = entity.Network,
                        Score = entity.Score
                    };
            }
        }

        public bool UpdateSport(SportEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sports
                        .Single(e => e.SportId == model.SportId);

                entity.MediaType = model.MediaType;
                entity.League = model.League;
                entity.HomeTeam = model.HomeTeam;
                entity.AwayTeam = model.AwayTeam;
                entity.Location = model.Location;
                entity.Time = model.Time;
                entity.Network = model.Network;
                entity.Score = model.Score;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSport(int sportId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sports
                        .Single(e => e.SportId == sportId);

                    ctx.Sports.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
