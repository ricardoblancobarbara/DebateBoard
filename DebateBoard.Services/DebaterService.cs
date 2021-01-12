using DebateBoard.Data;
using DebateBoard.Models.Debater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Services
{
    public class DebaterService
    {
        // Create
        public bool CreateDebater(DebaterCreate model)
        {
            var entity =
                new Debater()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    CreatedUtc = DateTimeOffset.UtcNow
        };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Debaters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read
        public IEnumerable<DebaterList> GetDebaters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Debaters
                        //.Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new DebaterList
                                {
                                    DebaterId = e.DebaterId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    UserName = e.UserName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        // Read
        public DebaterDetail GetDebaterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Debaters
                        //.Single(e => e.ArticleId == id && e.OwnerId == _userId);
                        .Single(e => e.DebaterId == id);

                return
                    new DebaterDetail
                    {
                        DebaterId = entity.DebaterId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        UserName = entity.UserName,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }

        // Update
        public bool UpdateDebater(DebaterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Debaters
                        //.Single(e => e.ArticleId == model.ArticleId && e.OwnerId == _userId);
                        .Single(e => e.DebaterId == model.DebaterId);

                entity.DebaterId = model.DebaterId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.UserName = model.UserName;
                entity.CreatedUtc = model.CreatedUtc;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete
        public bool DeleteDebater(int debaterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Debaters
                        //.Single(e => e.ArticleId == articleId && e.OwnerId == _userId);
                        .Single(e => e.DebaterId == debaterId);

                ctx.Debaters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
