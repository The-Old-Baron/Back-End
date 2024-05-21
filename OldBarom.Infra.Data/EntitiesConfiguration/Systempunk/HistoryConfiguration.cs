using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldBarom.Core.Domain.Model.Systempunk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Infra.Data.EntitiesConfiguration.Systempunk
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t=>t.Description).HasMaxLength(500).IsRequired();
            builder.Property(t => t.Date).IsRequired();
            builder.Property(t => t.User).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Type).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Status).HasMaxLength(100).IsRequired();
        }
    }
}
