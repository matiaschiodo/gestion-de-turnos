using Domain.Services;
using Domain.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    //Falta configurar de manera correcta        
    app.UseHttpLogging();
}

app.UseHttpsRedirection();

app.MapGet("/clientes/{id}", (int id) => {
    EspecialidadService especialidadService = new EspecialidadService();

    return especialidadService.Get(id);
})
.WithName("GetCliente")
.WithOpenApi();

app.MapGet("/clientes", () => {
    EspecialidadService especialidadService = new EspecialidadService();

    return especialidadService.GetAll();
})
.WithName("GetAllClientes")
.WithOpenApi();

app.MapPost("/clientes", (Especialidad especialidad) => {
    EspecialidadService especialidadService = new EspecialidadService();
    especialidadService.Add(especialidad);
})
.WithName("AddCliente")
.WithOpenApi();

app.MapPut("/clientes", (Especialidad especialidad) => {
    EspecialidadService especialidadService = new EspecialidadService();
    especialidadService.Update(especialidad);
})
.WithName("UpdateCliente")
.WithOpenApi();

app.MapDelete("/clientes/{id}", (int id) => {
    EspecialidadService especialidadService = new EspecialidadService();
    especialidadService.Delete(id);
})
.WithName("DeleteCliente")
.WithOpenApi();

app.Run();
