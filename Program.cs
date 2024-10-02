using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicione servi�os ao cont�iner.
string? mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<SalaoContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

// Adiciona CORS com pol�tica nomeada
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:3000") // Substitua pelo dom�nio correto do seu frontend
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Adiciona controladores e Swagger
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend API", Version = "v1" });
});

var app = builder.Build();

// Configure o pipeline de solicita��o HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend API V1");
    });
}

// Ativa o middleware de CORS com a pol�tica configurada
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
