using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldBarom.Core.Domain.Entities.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Infra.Data.EntitiesConfiguration.Basic
{
    public class ContryStateConfigure : IEntityTypeConfiguration<CountryStates>
    {
        public void Configure(EntityTypeBuilder<CountryStates> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.CountryId).IsRequired();
            builder.HasOne(e => e.Country).WithMany().HasForeignKey(e => e.CountryId);
            builder.Property(a => a.CreatedAt).IsRequired();
            builder.Property(a => a.UpdatedAt).IsRequired();
        }
    }
}
