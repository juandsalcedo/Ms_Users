using Microsoft.EntityFrameworkCore;
using Ms_Users.Domain.Repository;
using Ms_Users.Infraestructure.Repository;
using Ms_Users.Application.Service;
using Ms_Users.Infraestructure.DbContext;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURACIÓN DE BASE DE DATOS
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// 2. INYECCIÓN DE DEPENDENCIAS (Aquí estaba el fallo)
// Primero el Repositorio (Infraestructura)
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Luego el Servicio (Aplicación)
builder.Services.AddScoped<IUserService, UserServiceImp>();

// 3. CONTROLADORES Y SWAGGER
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

var app = builder.Build();

// 4. CONFIGURACIÓN DE SWAGGER PARA VISUALIZACIÓN
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();   // <--- Esto genera el JSON
    app.UseSwaggerUI(); // <--- Esto genera la interfaz con botones
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();