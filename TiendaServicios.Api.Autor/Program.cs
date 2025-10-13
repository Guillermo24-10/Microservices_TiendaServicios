using TiendaServicios.Api.Autor.Extensions;
using TiendaServicios.Api.Autor.Extensions.Middleware;
using TiendaServicios.Autor.Application.Extensions;
using TiendaServicios.Autor.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices(); // Adding Application Layer services
builder.Services.AddInfrastructureServices(builder.Configuration); // Adding Infrastructure Layer services
builder.Services.AddApiServices(); // Adding API Layer services


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

app.AddMiddleware(); // Adding custom middleware

app.Run();
