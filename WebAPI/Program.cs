using Domain.Services;
using Domain.Model;
using Domain.Interfaces;  
using Domain;            
using Microsoft.EntityFrameworkCore; 
using WebAPI.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ClinicaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEspecialidadService, EspecialidadService>();
builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddScoped<IObraSocialService, ObraSocialService>();
builder.Services.AddScoped<ITurnoService, TurnoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

// Endpoints
new EspecialidadEndpoint(app, builder.Services.BuildServiceProvider().GetService<IEspecialidadService>()); // Inyección de servicio
new HorarioEndpoint(app, builder.Services.BuildServiceProvider().GetService<IHorarioService>());
new ObraSocialEndpoint(app, builder.Services.BuildServiceProvider().GetService<IObraSocialService>());
new TurnoEndpoint(app, builder.Services.BuildServiceProvider().GetService<ITurnoService>());
new UsuarioEndpoint(app, builder.Services.BuildServiceProvider().GetService<IUsuarioService>());

app.Run();