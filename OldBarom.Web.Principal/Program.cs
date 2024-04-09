using OldBarom.Infra.IoC;
using OldBarom.Core.Domain.Account;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

SeedUserRoles(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

void SeedUserRoles(IApplicationBuilder app)
{
    using(var serviceScope = app.ApplicationServices.CreateScope())
    {
        var userSeeds = serviceScope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();
        userSeeds.SeedRoles();
        userSeeds.SeedUsers();
        
        var worldSeeds = serviceScope.ServiceProvider.GetRequiredService<ISeedWorldInitial>();
        worldSeeds.SeedRegions();
        worldSeeds.SeedCountries();
        worldSeeds.SeedStates();
        worldSeeds.SeedCities();
    }
  
}
