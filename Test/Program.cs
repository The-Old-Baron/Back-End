using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OldBarom.Infra.Data.Context;
using OldBarom.Infra.IoC;
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

app.UseRouting(); // Add this line
app.UseAuthentication(); // Adicione esta linha
app.UseAuthorization(); // Adicione esta linha

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
    
});
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.MapRazorPages();

app.Run();
