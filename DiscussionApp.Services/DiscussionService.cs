using DiscussionApp.Contracts;
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

        public bool CreateDiscussion(IDiscussionCreate model)
        {
            var entity =
                new Discussion()
                {
                    DiscussionId = model.DiscussionId,
                    MediaType = model.MediaType,
                    FilmId = model.FilmId,
                    TelevisionId = model.TelevisionId,
                    SportId = model.SportId,
                    CreatorId = _userId,
                    DiscussionTitle = model.DiscussionTitle,
                    CreatedUTC = DateTimeOffset.Now,
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
                        .Where(d => d.FilmId != 1 || d.TelevisionId != 1 || d.SportId != 1)
                        .Select(
                            d =>
                                new DiscussionListItem
                                {
                                    DiscussionId = d.DiscussionId,
                                    MediaType = d.MediaType,
                                    FilmId = d.FilmId,
                                    TelevisionId = d.TelevisionId,
                                    SportId = d.SportId,
                                    FilmTitle = d.Film.Title,
                                    TelevisionTitle = d.TVShow.Title,
                                    //Matchup = d.Sport.Matchup,
                                    DiscussionTitle = d.DiscussionTitle,
                                    CreatorId = d.CreatorId,
                                    CreatorUsername = ctx.Users.Where(y => y.Id == d.CreatorId.ToString()).FirstOrDefault().UserName,
                                    CreatedUTC = d.CreatedUTC,
                                    PostCount = ctx.Posts.Where(p => p.DiscussionId == d.DiscussionId).Count(),
                                    LastPostCreatorUsername = ctx.Users.Where(x => x.Id == ctx.Posts.Where(p => p.DiscussionId == d.DiscussionId).OrderByDescending(y => y.CreatedUTC).FirstOrDefault().CreatorId.ToString()).FirstOrDefault().UserName,
                                    LastPostUTC = ctx.Posts.Where(p => p.DiscussionId == d.DiscussionId).OrderByDescending(x => x.CreatedUTC).FirstOrDefault().CreatedUTC
                                }
                        );
                return query.OrderByDescending(x => x.LastPostUTC).ToArray();
            }
        }

        public IEnumerable<DiscussionListItem> GetDiscussionsByType(MediaType type)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Discussions
                        .Where(d => d.MediaType == type)
                        .Select(
                            d =>
                                new DiscussionListItem
                                {
                                    DiscussionId = d.DiscussionId,
                                    MediaType = d.MediaType,
                                    FilmId = d.FilmId,
                                    TelevisionId = d.TelevisionId,
                                    SportId = d.SportId,
                                    FilmTitle = d.Film.Title,
                                    TelevisionTitle = d.TVShow.Title,
                                    //Matchup = d.Sport.Matchup,
                                    DiscussionTitle = d.DiscussionTitle,
                                    CreatorId = d.CreatorId,
                                    CreatorUsername = ctx.Users.Where(y => y.Id == d.CreatorId.ToString()).FirstOrDefault().UserName,
                                    CreatedUTC = d.CreatedUTC,
                                    PostCount = ctx.Posts.Where(p => p.DiscussionId == d.DiscussionId).Count(),
                                    LastPostCreatorUsername = ctx.Users.Where(x => x.Id == ctx.Posts.Where(p => p.DiscussionId == d.DiscussionId).OrderByDescending(y => y.CreatedUTC).FirstOrDefault().CreatorId.ToString()).FirstOrDefault().UserName,
                                    LastPostUTC = ctx.Posts.Where(p => p.DiscussionId == d.DiscussionId).OrderByDescending(x => x.CreatedUTC).FirstOrDefault().CreatedUTC
                                }
                            );
                return query.OrderByDescending(x => x.LastPostUTC).ToArray();
            }
        }

        public IEnumerable<DiscussionListItem> GetTrendingDiscussions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Discussions
                        .Select(
                            d =>
                                new DiscussionListItem
                                {
                                    DiscussionId = d.DiscussionId,
                                    MediaType = d.MediaType,
                                    FilmId = d.FilmId,
                                    TelevisionId = d.TelevisionId,
                                    SportId = d.SportId,
                                    FilmTitle = d.Film.Title,
                                    TelevisionTitle = d.TVShow.Title,
                                    //Matchup = d.Sport.Matchup,
                                    DiscussionTitle = d.DiscussionTitle,
                                    CreatorId = d.CreatorId,
                                    CreatorUsername = ctx.Users.Where(y => y.Id == d.CreatorId.ToString()).FirstOrDefault().UserName,
                                    CreatedUTC = d.CreatedUTC,
                                    PostCount = ctx.Posts.Where(p => p.DiscussionId == d.DiscussionId).Count(),
                                    LastPostCreatorUsername = ctx.Users.Where(x => x.Id == ctx.Posts.Where(p => p.DiscussionId == d.DiscussionId).OrderByDescending(y => y.CreatedUTC).FirstOrDefault().CreatorId.ToString()).FirstOrDefault().UserName,
                                    LastPostUTC = ctx.Posts.Where(p => p.DiscussionId == d.DiscussionId).OrderByDescending(x => x.CreatedUTC).FirstOrDefault().CreatedUTC
                                }
                            );
                return query.OrderByDescending(x => x.PostCount).Take(5).ToArray();
            }
        }

        public DiscussionDetail GetDiscussionById(Guid discussionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Discussions
                        .Single(d => d.DiscussionId == discussionId);
                return
                    new DiscussionDetail
                    {
                        DiscussionId = entity.DiscussionId,
                        MediaType = entity.MediaType,
                        FilmId = entity.FilmId,
                        TelevisionId = entity.TelevisionId,
                        SportId = entity.SportId,
                        DiscussionTitle = entity.DiscussionTitle,
                        CreatorId = entity.CreatorId,
                        CreatorUsername = ctx.Users.Where(y => y.Id == entity.CreatorId.ToString()).FirstOrDefault().UserName,
                        CreatedUTC = entity.CreatedUTC,
                        PostCount = ctx.Posts.Where(p => p.DiscussionId == entity.DiscussionId).Count(),
                    };
            }
        }

        public bool UpdateFilmDiscussion(DiscussionEdit model)
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

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateTelevisionDiscussion(DiscussionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Discussions
                        .Single(e => e.DiscussionId == model.DiscussionId);

                entity.MediaType = model.MediaType;
                entity.TelevisionId = model.TelevisionId;
                entity.DiscussionTitle = model.DiscussionTitle;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateSportDiscussion(DiscussionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Discussions
                        .Single(e => e.DiscussionId == model.DiscussionId);

                entity.MediaType = model.MediaType;
                entity.SportId = model.SportId;
                entity.DiscussionTitle = model.DiscussionTitle;

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
                        .Single(d => d.DiscussionId == discussionId);

                ctx.Discussions.Remove(entity);
                bool result = ctx.SaveChanges() == 1;

                var posts =
                    ctx
                        .Posts
                        .Where(d => d.DiscussionId == discussionId);

                ctx.Posts.RemoveRange(posts);
                result &= ctx.SaveChanges() == 1;
                return result;
            }
        }

        // Helper Methods
        public string GetDiscussionTitle(Guid discussionId)
        {
            using (var ctx = new ApplicationDbContext())
                return ctx.Discussions.Where(d => d.DiscussionId == discussionId).Single().DiscussionTitle;
        }

        public string GetDiscussionCreatorId(Guid discussionId)
        {
            using (var ctx = new ApplicationDbContext())
                return ctx.Discussions.Where(d => d.DiscussionId == discussionId).Single().CreatorId.ToString();
        }

        public string GetFilmTitle(int filmId)
        {
            using (var ctx = new ApplicationDbContext())
                return ctx.Films.Where(d => d.FilmId == filmId).Single().Title;
        }

        public string GetTelevisionTitle(int televisionId)
        {
            using (var ctx = new ApplicationDbContext())
                return ctx.TVShows.Where(d => d.TelevisionId == televisionId).Single().Title;
        }

        public string GetSportMatchup(int sportId)
        {
            using (var ctx = new ApplicationDbContext())
                return ctx.Sports.Where(d => d.SportId == sportId).Single().Matchup;
        }

        public string GetFilmId(int filmId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Films.Where(d => d.FilmId == filmId).Single().FilmId.ToString();
            }
        }

        public string GetTelevisionId(int televisionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.TVShows.Where(d => d.TelevisionId == televisionId).Single().TelevisionId.ToString();
            }
        }

        public string GetSportId(int sportId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Sports.Where(d => d.SportId == sportId).Single().SportId.ToString();
            }
        }
    }
}
