namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiscussionApp.WebMVC.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DiscussionApp.WebMVC.Data.ApplicationDbContext";
        }

        protected override void Seed(DiscussionApp.WebMVC.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Films.AddOrUpdate(
              f => f.Title,
              new Film
              {
                  FilmId = 1,
                  MediaType = MediaType.Film,
                  Title = "Default",
                  Director = "Default",
                  Writer = "Default",
                  Stars = "Default",
                  Cinematographer = "Default",
                  Editor = "Default",
                  Synopsis = "Default",
                  Genre1 = FilmGenreType.None,
                  Genre2 = FilmGenreType.None,
                  Year = "0000",
                  Released = false,
                  Runtime = 0,
                  Rating = "0",
              }
            );
            context.TVShows.AddOrUpdate(
              t => t.Title,
              new TVShow
              {
                  TelevisionId = 1,
                  MediaType = MediaType.Television,
                  Title = "Default",
                  Creator = "Default",
                  Director = "Default",
                  Writer = "Default",
                  Stars = "Default",
                  Synopsis = "Default",
                  Genre1 = TVGenreType.None,
                  Genre2 = TVGenreType.None,
                  Network = "Default",
                  Released = false,
                  Year = "0000",
                  DateAired = "Default",
                  Runtime = 0,
                  Rating = "0",
                  Cinematographer = "Default",
                  Editor = "Default",
              }
            );
            context.Sports.AddOrUpdate(
                s => s.League,
                new Sport
                {
                    SportId = 1,
                    MediaType = MediaType.Sports,
                    League = League.None,
                    HomeTeam = "Default",
                    AwayTeam = "Default",
                    Location = "Default",
                    Time = DateTime.Now,
                    Network = "Default",
                    Score = "Default",
                }
            );
        }
    }
}
