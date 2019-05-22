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
        private readonly Guid _userId;

        public DiscussionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDiscussion(DiscussionCreate model)
        {
            var entity =
                new Discussion()
                {
                    DiscussionId = model.DiscussionId,
                    MediaType = model.MediaType,
                    FilmId = model.FilmId,
                    TelevisionId = model.TelevisionId,
                    CreatorId = _userId,
                    DiscussionTitle = model.DiscussionTitle,
                    CreatedUTC = DateTimeOffset.Now,
                    Film = model.Film,
                };

            var newPost =
                new Post()
                {
                    PostId = Guid.NewGuid(),
                    DiscussionId = model.DiscussionId,
                    CreatorId = _userId,
                    CreatedUTC = DateTimeOffset.Now,
                    Body = model.Body
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Discussions.Add(entity);
                bool result = ctx.SaveChanges() == 1;
                ctx.Posts.Add(newPost);
                result &= ctx.SaveChanges() == 1;
                return result;
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
                                    TelevisionId = e.TelevisionId,
                                    FilmTitle = e.Film.Title,
                                    DiscussionTitle = e.DiscussionTitle,
                                    CreatorId = e.CreatorId,
                                    CreatorUsername = ctx.Users.Where(y => y.Id == e.CreatorId.ToString()).FirstOrDefault().UserName,
                                    CreatedUTC = e.CreatedUTC,
                                    PostCount = ctx.Posts.Where(p => p.DiscussionId == e.DiscussionId).Count(),
                                    LastPostCreatorUsername = ctx.Users.Where(x => x.Id == ctx.Posts.Where(p => p.DiscussionId == e.DiscussionId).OrderByDescending(y => y.CreatedUTC).FirstOrDefault().CreatorId.ToString()).FirstOrDefault().UserName,
                                    LastPostUTC = ctx.Posts.Where(p => p.DiscussionId == e.DiscussionId).OrderByDescending(x => x.CreatedUTC).FirstOrDefault().CreatedUTC
                                }
                        );
                return query.OrderByDescending(x => x.LastPostUTC).ToArray();
            }
        }

        public DiscussionDetail GetDiscussionById(Guid discussionId)
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
                        TelevisionId = entity.TelevisionId,
                        //SportId = entity.SportId,
                        DiscussionTitle = entity.DiscussionTitle,
                        CreatorId = entity.CreatorId,
                        CreatorUsername = ctx.Users.Where(y => y.Id == entity.CreatorId.ToString()).FirstOrDefault().UserName,
                        CreatedUTC = entity.CreatedUTC,
                        PostCount = ctx.Posts.Where(p => p.DiscussionId == entity.DiscussionId).Count(),
                        //Film = entity.Film,
                        //TVShow = entity.TVShow,
                        //Sport = entity.Sport
                    };
            }
        }

        public bool UpdateDiscussion(DiscussionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Discussions
                        .Single(e => e.DiscussionId == model.DiscussionId);

                entity.MediaType = model.MediaType;
                entity.FilmId = model.FilmId;
                entity.DiscussionTitle = model.DiscussionTitle;
                //entity.Film = model.Film;
                //entity.TVShow = model.TVShow;
                //entity.Sport = model.Sport;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDiscussion(Guid discussionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Discussions
                        .Single(e => e.DiscussionId == discussionId);

                ctx.Discussions.Remove(entity);
                bool result = ctx.SaveChanges() == 1;

                var posts =
                    ctx
                        .Posts
                        .Where(e => e.DiscussionId == discussionId);

                ctx.Posts.RemoveRange(posts);
                result &= ctx.SaveChanges() == 1;
                return result;
            }
        }

        // Helper Methods
        public string GetDiscussionTitle(Guid discussionId)
        {
            using (var ctx = new ApplicationDbContext())
                return ctx.Discussions.Where(e => e.DiscussionId == discussionId).Single().DiscussionTitle;
        }

        public string GetDiscussionCreatorId(Guid discussionId)
        {
            using (var ctx = new ApplicationDbContext())
                return ctx.Discussions.Where(e => e.DiscussionId == discussionId).Single().CreatorId.ToString();
        }

        public string GetFilmTitle(int filmId)
        {
            using (var ctx = new ApplicationDbContext())
                return ctx.Films.Where(e => e.FilmId == filmId).Single().Title;
        }

        //public string GetFilmId(Guid discussionId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //        return ctx.Discussions.Where(e => e.DiscussionId == discussionId).Single().FilmId.ToString();
        //}

        public string GetFilmId(int filmId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Films.Where(e => e.FilmId == filmId).Single().FilmId.ToString();
            }
        }
    }
}
