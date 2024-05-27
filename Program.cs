using Microsoft.EntityFrameworkCore;
using soporte_back_dotnet.Model;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configuración del servicio de base de datos
var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<supportDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configuración de los servicios de controladores
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeo de los controladores
app.MapControllers();

app.Run();
