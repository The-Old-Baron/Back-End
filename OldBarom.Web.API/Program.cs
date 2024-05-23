using OldBarom.Core.Domain.Interface.Account;
using OldBarom.Infra.IoC;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);  
builder.Services.AddInfrastructureSwagger(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseRouting();
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var seedUserRoleInitial = services.GetRequiredService<ISeedUserRoleInitial>();

    seedUserRoleInitial.SeedRole();
    seedUserRoleInitial.SeedUser();
}
    app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
