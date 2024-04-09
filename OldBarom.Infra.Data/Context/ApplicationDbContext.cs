using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Entities.LinkList;
using OldBarom.Core.Domain.Entities.Portifolio;
using OldBarom.Core.Domain.Entities.TeamController;
using OldBarom.Infra.Data.Identity;
using OldBarom.Infra.Data.Repository.Portifolio;
using Newtonsoft.Json;
namespace OldBarom.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        // Basic
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<CountryStates> CountryStates { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        // MyLinkList
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Links> Links { get; set; }

        // Portifolio
        public DbSet<Projects> Projects { get; set; }

        // Team
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamCategories> TeamCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder.Entity<Projects>()
                .Property(F => F.ProjectInformations)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<int, ProjectInformations>>(v),
                    new ValueComparer<Dictionary<int, ProjectInformations>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToDictionary(v => v.Key, v => v.Value)
                        )
                );
            
        }
    }

}
