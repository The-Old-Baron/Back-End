using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OldBarom.Core.Domain.Model.Systempunk;

namespace OldBarom.Infra.Data.Configuration.Systempunk
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(500).IsRequired();
            builder.Property(t => t.Date).IsRequired();
            builder.Property(t => t.User).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Type).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Status).HasMaxLength(100).IsRequired();
        }
    }
}
