using DebateBoard.Data;
using DebateBoard.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Services
{
    public class ArticleService
    {
        private readonly Guid _userId;
        //private readonly string _userId;

        public ArticleService(Guid userId)
        {
            _userId = userId;
        }

        //public ArticleService(string userId)
        //{
        //    _userId = userId;
        //}

        // CRRUD
        // Create
        public bool CreateArticle(ArticleCreate model)
        {
            var entity = new Article() {
                //ArticleId = model.ArticleId,
                Title = model.Title,
                SubTitle = model.SubTitle,
                Content = model.Content,
                Category = model.Category,
                Subject = model.Subject,
                //AuthorId = model.ApplicationUser.UserName,
                AuthorId = _userId,
                Points = model.Points,
                CreatedUtc = DateTimeOffset.Now,
                //ModifiedUtc = model.ModifiedUtc
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Articles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read All 
        public IEnumerable<ArticleList> GetArticles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                        .Articles
                        //.Where(e => e.AuthorId == _userId)
                        .Select(e => new ArticleList {
                                ArticleId = e.ArticleId,
                                Category = e.Category,
                                Subject = e.Subject,
                                Title = e.Title,
                                SubTitle = e.SubTitle,
                                Content = e.Content,
                                //AuthorId = e.ApplicationUser.UserName,
                                AuthorId = e.AuthorId,
                                Points = e.Points,
                                CreatedUtc = e.CreatedUtc,
                                ModifiedUtc = e.ModifiedUtc
                            }
                        );
                return query.ToArray();
            }
        }

        // Read Single
        public ArticleDetail GetArticleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Articles
                        //.Single(e => e.ArticleId == id && e.AuthorId == _userId);
                        .Single(e => e.ArticleId == id);

                return
                    new ArticleDetail
                    {
                        ArticleId = entity.ArticleId,
                        Category = entity.Category,
                        Subject = entity.Subject,
                        Title = entity.Title,
                        SubTitle = entity.SubTitle,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        // Update
        public bool UpdateArticle(ArticleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Articles
                        //.Single(e => e.ArticleId == model.ArticleId && e.AuthorId == _userId);
                        .Single(e => e.ArticleId == model.ArticleId);

                        entity.Category = model.Category;
                        entity.Subject = model.Subject;
                        entity.Title = model.Title;
                        entity.SubTitle = model.SubTitle;
                        entity.Content = model.Content;
                        entity.ModifiedUtc = DateTimeOffset.Now;

                        return ctx.SaveChanges() == 1;
            }
        }

        // Delete
        public bool DeleteArticle(int articleId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context
                    .Articles
                    //.Single(e => e.ArticleId == articleId && e.AuthorId == _userId);
                    .Single(e => e.ArticleId == articleId);

                context.Articles.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }

    }
}
