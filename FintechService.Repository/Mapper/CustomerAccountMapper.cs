using FintechService.Domain.PFintechServiceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FintechService.Repository.Mapper
{
    public class CustomerAccountMapper : BaseEntityMap<CustomerAccount>

    {
        protected override void Map(EntityTypeBuilder<CustomerAccount> eb)
        {
            eb.Property(x => x.Id).HasColumnType("uniqueidentifier");
            eb.Property(x => x.CustomerId).HasColumnType("nvarchar(11)");
            eb.Property(x => x.AccountName).HasColumnType("nvarchar(50)");
            eb.Property(x => x.Currency).HasColumnType("nvarchar(50)");
            eb.ToTable("CustomerAccount");
        }
    }
}
