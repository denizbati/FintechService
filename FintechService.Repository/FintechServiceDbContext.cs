using FintechService.Domain.Entities;
using FintechService.Repository.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FintechService.Repository
{
    public class FintechServiceDbContext : DbContext
    {
        public FintechServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CustomerMapper().BaseMap(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ChangeTracker.DetectChanges();
            var added = this.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in added)
            {
                if (entity is Entity track)
                {
                    track.CreatedDate = DateTime.Now;
                    track.IsActive = true;
                }
            }

            var modified = this.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in modified)
            {
                if (entity is Entity track)
                {
                    track.ModifiedDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync();
        }

    }
}