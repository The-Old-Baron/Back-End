using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OldBarom.Core.Application.Mappings;
using OldBarom.Core.Domain.Account;
using OldBarom.Core.Domain.Interfaces;
using OldBarom.Infra.Data.Configure;
using OldBarom.Infra.Data.Context;
using OldBarom.Infra.Data.Identity;
using OldBarom.Infra.Data.Repositories;

namespace OldBarom.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, UserConfigure>();

            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("OldBarom.Core.Application");
            //services.AddMediatR(myHandlers);

            return services;
        }
    }
}
