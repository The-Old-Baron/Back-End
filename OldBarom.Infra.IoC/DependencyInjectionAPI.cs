using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OldBarom.Core.Application.Interface;
using OldBarom.Core.Application.Interface.Systempunk;
using OldBarom.Core.Application.Mappings;
using OldBarom.Core.Application.Serivces.Systempunk;
using OldBarom.Core.Domain.Interface.Account;
using OldBarom.Infra.Data.Context;
using OldBarom.Infra.Data.Identity;

namespace OldBarom.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IHistoryService, HistoryService>();

            services.Add(new ServiceDescriptor(typeof(IMapper), new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new DTOtoCommandMappingProfile())))));

            var myHandlers = AppDomain.CurrentDomain.Load("OldBarom.Core.Application");
            services.AddMediatR(myHandlers);  

            return services;
        }
    }
}