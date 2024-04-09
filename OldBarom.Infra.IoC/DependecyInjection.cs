using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OldBarom.Core.Application.Mappings;
using OldBarom.Core.Domain.Account;
using OldBarom.Infra.Data.Context;
using OldBarom.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using OldBarom.Infra.IoC.Services;
using OldBarom.Core.Domain.Repository.Basic;
using OldBarom.Infra.Data.Repository.Basic;
using OldBarom.Core.Application.Interfaces.Bases;
using OldBarom.Core.Application.Services.Basic;
using AutoMapper;
using OldBarom.Core.Domain.Repository.Portifolio;
using OldBarom.Infra.Data.Repository.Portifolio;
using OldBarom.Core.Domain.Repository.TeamController;
using OldBarom.Infra.Data.Repository.TeamController;
namespace OldBarom.Infra.IoC
{
    public static class DependecyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddSingleton(new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DomainToDTOMappingProfile>())));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContextConnection"), 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.ConfigureApplicationCookie(options => 
                options.AccessDeniedPath = "/Identity/Account/AccessDenied");
            
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<ISeedWorldInitial, SeedWorldInitial>();

            // Basic Dependecy injection
            services.AddScoped<IRegionsRepository, RegionsRepository>();
            services.AddScoped<ICityRepository, CitiesRepository>();
            services.AddScoped<ICountryStateRepository, CountryStateRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();

            services.AddScoped<IRegionsService, RegionsServices>();
            services.AddScoped<ICitiesService, CitiesServices>();
            services.AddScoped<ICountryStateRepository, CountryStateRepository>();
            services.AddScoped<ICountriesService, CountriesServices>();


            // Portifolio Dependency Injection
            services.AddScoped<IProjectsRepository, ProjectsRepository>();

            // Team Controller
            services.AddScoped<ITeamCategoriesRepository, TeamCategoriesRepository>();
            services.AddScoped<ITeamRepository, TeamRespository>();

            var myhandlers = AppDomain.CurrentDomain.Load("OldBarom.Core.Application");

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));
            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/Login";
                options.SlidingExpiration = true;
            });

            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                var clientId = "65099909019-e6fq1gck2j2motqfuno1jj38lajqhhin.apps.googleusercontent.com";
                var clientSecret = "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";

                if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
                {
                    throw new ArgumentException("Google OAuth settings are missing in the configuration");
                }

                googleOptions.ClientId = clientId;
                googleOptions.ClientSecret = clientSecret;
            });

            return services;
        }
    }
}
