using FintechService.Domain.PFintechServiceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechService.Repository.Mapper
{
    public class CustomerMapper : BaseEntityMap<Customer>

    {
        protected override void Map(EntityTypeBuilder<Customer> eb)
        {
            eb.Property(x => x.Id).HasColumnType("uniqueidentifier");
            eb.Property(x => x.IdentityNumber).HasColumnType("nvarchar(11)");
            eb.Property(x => x.Surname).HasColumnType("nvarchar(50)");
            eb.Property(x => x.Name).HasColumnType("nvarchar(50)");
            eb.ToTable("Customer");
        }
    }
}
