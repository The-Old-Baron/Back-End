using Microsoft.AspNetCore.Identity;
using OldBarom.Core.Domain.Account;
using OldBarom.Infra.Data.Identity;
using OldBarom.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using OldBarom.Infra.Data.Context;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRazorPages();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(
    options =>
    {
        options.SendGridKey = builder.Configuration["SendGridKey"];
        options.SendGridUser = builder.Configuration["SendGridUser"];
    }
    );
var app = builder.Build();
SeedUserRoles(app);
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

void SeedUserRoles(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var seed = serviceScope.ServiceProvider
            .GetService<ISeedUserRoleInitial>();
        seed.SeedRoles();
        seed.SeedUsers();
    }
}
