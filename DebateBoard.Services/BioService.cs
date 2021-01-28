using DebateBoard.Data;
using DebateBoard.Models.Bio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Services
{
    public class BioService
    {
        private readonly Guid _userId;

        public BioService(Guid userId)
        {
            _userId = userId;
        }

        // CRRUD
        // Create
        public bool CreateBio(BioCreate model)
        {
            var entity = new Bio()
            {
                BioId = model.BioId,
                Name = model.Name,
                Biography = model.Biography,
                Id = _userId.ToString(),
                //Id = model.ApplicationUser.,
                Points = model.Points,
                CreatedUtc = DateTimeOffset.Now,
                ModifiedUtc = model.ModifiedUtc
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bios.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read
        public IEnumerable<BioList> GetBios()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Bios
                        //.Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new BioList
                                {
                                    BioId = e.BioId,
                                    Name = e.Name,
                                    Biography = e.Biography,
                                    //Id = _userId.ToString(),
                                    Id = e.ApplicationUser.UserName,
                                    Points = e.Points,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );
                return query.ToArray();
            }
        }


        // Read
        public BioDetail GetBioById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bios
                        //.Single(e => e.CommentId == id && e.AuthorId == _userId);
                        .Single(e => e.BioId == id);

                return
                    new BioDetail
                    {
                        BioId = entity.BioId,
                        Name = entity.Name,
                        Biography = entity.Biography,
                        Id = entity.ApplicationUser.UserName,
                        Points = entity.Points,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        // Update
        public bool UpdateBio(BioEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bios
                        //.Single(e => e.CommentId == model.CommentId && e.AuthorId == _userId);
                        .Single(e => e.BioId == model.BioId);

                entity.Name = model.Name;
                entity.Biography = model.Biography;
                entity.Points = model.Points;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete
        public bool DeleteBio(int bioId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context
                    .Bios
                    //.Single(e => e.CommentId == commentId && e.AuthorId == _userId);
                    .Single(e => e.BioId == bioId);

                context.Bios.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
