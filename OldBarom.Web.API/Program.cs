using OldBarom.Core.Domain.Account;
using OldBarom.Infra.Data.Context;
using OldBarom.Infra.IoC; // Certifique-se de importar o namespace correto

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration); 
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

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