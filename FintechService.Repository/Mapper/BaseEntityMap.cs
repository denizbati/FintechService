using FintechService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechService.Repository.Mapper
{
    public abstract class BaseEntityMap<T> where T : Entity
    {
        protected abstract void Map(EntityTypeBuilder<T> eb);

        public void BaseMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>(bi =>
            {
                bi.Property(b => b.CreatedDate).HasColumnType("datetime");
                bi.Property(b => b.ModifiedDate).HasColumnType("datetime");
                bi.Property(b => b.IsActive).HasColumnType("bit");
                bi.HasKey(b => b.Id);
                Map(bi);
            });
        }
    }
}
