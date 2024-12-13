using Domain.Model;
using Domain.Interfaces; 
using Microsoft.AspNetCore.Mvc;
using Domain.Services;

namespace WebAPI.EndPoints
{
    public class EspecialidadEndpoint
    {
        public EspecialidadEndpoint(WebApplication app, IEspecialidadService service) // Inyección de dependencias
        {
            app.MapGet("/especialidades/{id}", (int id) => {
                var especialidad = service.Get(id);
                return especialidad is not null ? Results.Ok(especialidad) : Results.NotFound();
            }).WithName("GetEspecialidad").WithOpenApi();

            app.MapGet("/especialidades", () => {
                var especialidades = service.GetAll();
                return Results.Ok(especialidades);
            }).WithName("GetEspecialidades").WithOpenApi();

            app.MapPost("/especialidades", ([FromBody] Especialidad especialidad) => {
                service.Add(especialidad);
                return Results.Created($"/especialidades/{especialidad.Id}", especialidad);
            }).WithName("PostEspecialidad").WithOpenApi();

            app.MapPut("/especialidades/{id}", (int id, [FromBody] Especialidad especialidad) => {
                especialidad.Id = id; 
                service.Update(especialidad);
                return Results.NoContent();
            }).WithName("PutEspecialidad").WithOpenApi();

            app.MapDelete("/especialidades/{id}", (int id) => {
                service.Delete(id);
                return Results.NoContent();
            }).WithName("DeleteEspecialidad").WithOpenApi();
        }
    }
}