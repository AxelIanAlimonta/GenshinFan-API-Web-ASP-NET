using GenshinFan.Data;
using GenshinFan.Services.Implementations;
using GenshinFan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GenshinImpactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IElementoService, ElementoService>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<ITipoDeArmaService, TipoDeArmaService>();
builder.Services.AddScoped<IPersonajeService, PersonajeService>();
builder.Services.AddScoped<IArmaService, ArmaService>();
builder.Services.AddScoped<IPersonajeArmaRecomendada, PersonajeArmaRecomendadaService>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Usar la política de CORS configurada
app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
