using DebateBoard.Data;
using DebateBoard.Models;
using DebateBoard.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        // CRRUD
        // Create
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                Content = model.Content,
                Id = _userId.ToString(),
                ArticleId = model.ArticleId,
                Points = model.Points,
                CreatedUtc = DateTimeOffset.Now,
                ModifiedUtc = model.ModifiedUtc
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read
        public IEnumerable<CommentList> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        //.Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new CommentList
                                {
                                    CommentId = e.CommentId,
                                    Content = e.Content,
                                    Id = _userId.ToString(),
                                    ArticleId = e.ArticleId,
                                    Points = e.Points,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );
                return query.ToArray();
            }
        }


        // Read
        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        //.Single(e => e.CommentId == id && e.AuthorId == _userId);
                        .Single(e => e.CommentId == id);

                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        Content = entity.Content,
                        Id = _userId.ToString(),
                        ArticleId = entity.ArticleId,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        // Update
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        //.Single(e => e.CommentId == model.CommentId && e.AuthorId == _userId);
                        .Single(e => e.CommentId == model.CommentId);

                entity.Content = model.Content;
                entity.Id = _userId.ToString();
                entity.ArticleId = model.ArticleId;
                entity.Points = model.Points;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete
        public bool DeleteComment(int commentId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context
                    .Comments
                    //.Single(e => e.CommentId == commentId && e.AuthorId == _userId);
                    .Single(e => e.CommentId == commentId);

                context.Comments.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
