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
    public class TelevisionService
    {
        public bool CreateTVShow(TVShowCreate model)
        {
            var entity =
                    new TVShow()
                    {
                        MediaType = model.MediaType,
                        Title = model.Title,
                        Creator = model.Creator,
                        Stars = model.Stars,
                        Synopsis = model.Synopsis,
                        Genre1 = model.Genre1,
                        Genre2 = model.Genre2,
                        Network = model.Network,
                        Year = model.Year,
                        Released = model.Released,
                        Rating = model.Rating,
                        Runtime = model.Runtime
                        //DateAired = model.DateAired,
                        //Director = model.Director,
                        //Writer = model.Writer,
                        //Cinematographer = model.Cinematographer,
                        //Editor = model.Editor
                    };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TVShows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TVShowListItem> GetTVShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TVShows
                        .Where(d => d.TelevisionId != 1)
                        .Select(
                            e =>
                                new TVShowListItem
                                {
                                    TelevisionId = e.TelevisionId,
                                    Title = e.Title,
                                    Creator = e.Creator,
                                    Stars = e.Stars,
                                    Genre1 = e.Genre1,
                                    Genre2 = e.Genre2,
                                    Network = e.Network,
                                    Year = e.Year
                                }
                        );

                return query.ToArray();
            }
        }

        public TVShowDetail GetTVShowById(int televisionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TVShows
                        .Single(e => e.TelevisionId == televisionId);
                return
                    new TVShowDetail
                    {
                        TelevisionId = entity.TelevisionId,
                        MediaType = entity.MediaType,
                        Title = entity.Title,
                        Year = entity.Year,
                        Creator = entity.Creator,
                        Stars = entity.Stars,
                        Synopsis = entity.Synopsis,
                        Genre1 = entity.Genre1,
                        Genre2 = entity.Genre2,
                        Network = entity.Network,
                        Released = entity.Released,
                        Runtime = entity.Runtime,
                        Rating = entity.Rating
                        //Director = entity.Director,
                        //Writer = entity.Writer,
                        //Cinematographer = entity.Cinematographer,
                        //Editor = entity.Editor
                        //DateAired = entity.DateAired
                    };
            }
        }

        public bool UpdateTVShow(TVShowEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TVShows
                        .Single(e => e.TelevisionId == model.TelevisionId);

                entity.MediaType = model.MediaType;
                entity.Title = model.Title;
                entity.Year = model.Year;
                entity.Creator = model.Creator;
                entity.Synopsis = model.Synopsis;
                entity.Stars = model.Stars;
                entity.Genre1 = model.Genre1;
                entity.Genre2 = model.Genre2;
                entity.Network = model.Network;
                entity.Runtime = model.Runtime;
                entity.Rating = model.Rating;
                entity.Released = model.Released;
                //entity.Director = model.Director;
                //entity.Writer = model.Writer;
                //entity.Cinematographer = model.Cinematographer;
                //entity.Editor = model.Editor;
                //entity.DateAired = model.DateAired;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTVShow(int televisionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TVShows
                        .Single(e => e.TelevisionId == televisionId);

                ctx.TVShows.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        // Helper Methods
        public string GetTVTitle(int televisionId)
        {
            using (var ctx = new ApplicationDbContext())
                return ctx.TVShows.Where(e => e.TelevisionId == televisionId).Single().Title;
        }
    }
}
