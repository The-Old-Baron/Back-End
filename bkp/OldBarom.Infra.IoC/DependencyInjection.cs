
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OldBarom.Core.Application.Interfaces.Systempunk;
using OldBarom.Core.Application.Mappings;
using OldBarom.Core.Application.Services.Systempunk;
using OldBarom.Core.Domain.Interfaces;
using OldBarom.Infra.Data.Context;
using OldBarom.Infra.Data.Identity;
using OldBarom.Infra.Data.Repositories;
using MediatR;
using OldBarom.Core.Domain.Account;

namespace OldBarom.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            
            var myHandler = AppDomain.CurrentDomain.Load("OldBarom.Core.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandler));

            return services;
        }
    }
}
