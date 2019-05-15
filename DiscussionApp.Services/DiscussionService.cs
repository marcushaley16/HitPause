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
    public class DiscussionService
    {
        public bool CreateDiscussion(DiscussionCreate model)
        {
            var entity =
                new Discussion()
                {
                    MediaType = model.MediaType,
                    FilmId = model.FilmId,
                    //TelevisionId = model.TelevisionId,
                    Title = model.Title,
                    Comment = model.Comment,
                    Film = model.Film,
                    //TVShow = model.TVShow,
                    //Sport = model.Sport
                    //CreatedUtc = DateTimeOffset.Now,
                    //ModifiedUtc = DateTime.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Discussions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DiscussionListItem> GetDiscussions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Discussions
                        .Select(
                            e =>
                                new DiscussionListItem
                                {
                                    DiscussionId = e.DiscussionId,
                                    MediaType = e.MediaType,
                                    FilmId = e.FilmId,
                                    Title = e.Title,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public DiscussionDetail GetDiscussionById(int discussionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Discussions
                        .Single(e => e.DiscussionId == discussionId);
                return
                    new DiscussionDetail
                    {
                        DiscussionId = entity.DiscussionId,
                        MediaType = entity.MediaType,
                        FilmId = entity.FilmId,
                        //TelevisionId = entity.TelevisionId,
                        //SportId = entity.SportId,
                        Title = entity.Title,
                        Comment = entity.Comment,
                        Film = entity.Film,
                        //TVShow = entity.TVShow,
                        //Sport = entity.Sport,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateDiscussion(DiscussionEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Discussions
                        .Single(e => e.DiscussionId == model.DiscussionId);

                entity.MediaType = model.MediaType;
                entity.FilmId = model.FilmId;
                entity.Title = model.Title;
                entity.Comment = model.Comment;
                entity.Film = model.Film;
                //entity.TVShow = model.TVShow;
                //entity.Sport = model.Sport;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDiscussion(int discussionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Discussions
                        .Single(e => e.DiscussionId == discussionId);

                    ctx.Discussions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
