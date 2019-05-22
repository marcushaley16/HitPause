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
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    PostId = Guid.NewGuid(),
                    DiscussionId = model.DiscussionId,
                    CreatorId = _userId,
                    Body = model.Body,
                    CreatedUTC = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == model.PostId);

                entity.Body = model.Body;
                entity.ModifiedUTC = DateTimeOffset.Now;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(Guid postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == postId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public PostListItem GetPostById(Guid postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Where(x => x.PostId == postId).SingleOrDefault();

                var post = new PostListItem
                {
                    PostId = entity.PostId,
                    DiscussionId = entity.DiscussionId,
                    Body = entity.Body,
                    CreatorId = entity.CreatorId,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC,
                    CreatorUsername = ctx.Users.Where(x => x.Id == entity.CreatorId.ToString()).FirstOrDefault().UserName,
                };

                return post;
            }
        }

        public IEnumerable<PostListItem> GetPostsByDiscussion(Guid discussionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.DiscussionId == discussionId)
                        .Select(
                                e =>
                                    new PostListItem
                                    {
                                        PostId = e.PostId,
                                        DiscussionId = e.DiscussionId,
                                        Body = e.Body,
                                        CreatorId = e.CreatorId,
                                        CreatedUTC = e.CreatedUTC,
                                        ModifiedUTC = e.ModifiedUTC,
                                        CreatorUsername = ctx.Users.Where(x => x.Id == e.CreatorId.ToString()).FirstOrDefault().UserName,
                                    }
                        );

                return query.OrderBy(x => x.CreatedUTC).ToArray();
            }
        }
    }
}
