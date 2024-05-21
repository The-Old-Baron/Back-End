using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OldBarom.Core.Domain.Model.Base;
using OldBarom.Core.Domain.Model.Systempunk;
using OldBarom.Infra.Data.Identity;
using System.Reflection;

namespace OldBarom.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<History> Histories { get; set; }
        public DbSet<Keywords> Keywords { get; set; }
        public DbSet<Tags> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}