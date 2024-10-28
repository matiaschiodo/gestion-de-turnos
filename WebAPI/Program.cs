using Domain.Services;
using Domain.Model;
using WebAPI.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

builder.Services.AddScoped<EspecialidadService>();
builder.Services.AddScoped<HorarioService>();
builder.Services.AddScoped<ObraSocialService>();
builder.Services.AddScoped<TurnoService>();
builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Falta configurar de manera correcta        
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

new EspecialidadEndpoint(app);
new HorarioEndpoint(app);
new ObraSocialEndpoint(app);
new TurnoEndpoint(app);
new UsuarioEndpoint(app);

app.Run();
