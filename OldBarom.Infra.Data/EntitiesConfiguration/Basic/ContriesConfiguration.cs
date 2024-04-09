using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldBarom.Core.Domain.Entities.Basic;

namespace OldBarom.Infra.Data.EntitiesConfiguration.Basic
{
    public class ContriesConfiguration : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.ISO3).IsRequired().HasMaxLength(10);
            builder.Property(a => a.NumericCode).IsRequired().HasMaxLength(10);
            builder.Property(a => a.ISO2).IsRequired().HasMaxLength(10);
            builder.Property(a => a.Currency).IsRequired().HasMaxLength(10);
            builder.Property(a => a.CurrencyName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.RegionId).IsRequired();
            builder.HasOne(e => e.Regions).WithMany().HasForeignKey(e => e.RegionId);
            builder.Property(a => a.CreatedAt).IsRequired();
            builder.Property(a => a.UpdatedAt).IsRequired();
        }
    }
}
