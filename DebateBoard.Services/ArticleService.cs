using DebateBoard.Data;
using DebateBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Services
{
    public class ArticleService
    {
        // Create
        public bool CreateArticle(ArticleCreate model)
        {
            var entity =
                new Article()
                {
                    Title = model.Title,
                    Content = model.Content
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Articles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read
        public IEnumerable<ArticleList> GetArticles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Articles
                        //.Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new ArticleList
                                {
                                    ArticleId = e.ArticleId,
                                    Title = e.Title
                                }
                        );

                return query.ToArray();
            }
        }


        // Read
        public ArticleDetail GetArticleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Articles
                        //.Single(e => e.ArticleId == id && e.OwnerId == _userId);
                        .Single(e => e.ArticleId == id);

                return
                    new ArticleDetail
                    {
                        ArticleId = entity.ArticleId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc
                        //ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }



    }
}
