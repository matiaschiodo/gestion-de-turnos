using Domain.Model;
using Domain.Interfaces; 
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints
{
    public class HorarioEndpoint
    {
        public HorarioEndpoint(WebApplication app, IHorarioService service) 
        {
            app.MapGet("/horarios/{id}", (int id) => {
                var horario = service.Get(id);
                return horario is not null ? Results.Ok(horario) : Results.NotFound();
            }).WithName("GetHorario").WithOpenApi();

            app.MapGet("/horarios", () => {
                var horarios = service.GetAll();
                return Results.Ok(horarios);
            }).WithName("GetHorarios").WithOpenApi();

            app.MapPost("/horarios", ([FromBody] Horario horario) => {
                service.Add(horario);
                return Results.Created($"/horarios/{horario.Id}", horario);
            }).WithName("PostHorario").WithOpenApi();

            app.MapPut("/horarios/{id}", (int id, [FromBody] Horario horario) => {
                horario.Id = id;
                service.Update(horario);
                return Results.NoContent();
            }).WithName("PutHorario").WithOpenApi();

            app.MapDelete("/horarios/{id}", (int id) => {
                service.Delete(id);
                return Results.NoContent();
            }).WithName("DeleteHorario").WithOpenApi();
        }
    }
}