using OldBarom.Core.Domain.Account;
using OldBarom.Infra.Data.Context;
using OldBarom.Infra.IoC; // Certifique-se de importar o namespace correto

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var dependencyInjection = builder.Services.AddInfrastructureAPI(builder.Configuration); // Adicione esta linha

var app = builder.Build();

//SeedWorldInitial();
//SeedUsers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
// Add Initial Content

// void SeedWorldInitial()
// {
//     using var scope = app.Services.CreateScope();
//     var services = scope.ServiceProvider;
//     var context = services.GetRequiredService<ApplicationDbContext>();
//     var seed = services.GetRequiredService<ISeedWorldInitial>();
//     seed.SeedContinents();
//     seed.SeedCountries();
//     seed.SeedStates();
//     seed.SeedCities();
//     context.SaveChanges();
// }

// void SeedUsers()
// {
//     using var scope = app.Services.CreateScope();
//     var services = scope.ServiceProvider;
//     var context = services.GetRequiredService<ApplicationDbContext>();
//     var seed = services.GetRequiredService<ISeedUserRoleInitial>();
//     seed.SeedRoles();
//     seed.SeedUsers();

//     context.SaveChanges();
// }