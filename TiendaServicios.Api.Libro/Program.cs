using TiendaServicios.Api.Libro.Extensions;
using TiendaServicios.Api.Libro.Extensions.Middleware;
using TiendaServicios.Libro.Application.Extensions;
using TiendaServicios.Libro.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplicationServices(); // injection application
builder.Services.AddInfrastructureServices(builder.Configuration); // injection infrastructure
builder.Services.AddServicesApi(); // injection presentation


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

app.AddMiddleware(); // Uso Middleware

app.Run();
