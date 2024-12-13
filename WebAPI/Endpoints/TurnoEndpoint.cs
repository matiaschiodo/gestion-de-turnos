using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints
{
    public class TurnoEndpoint
    {
        public TurnoEndpoint(WebApplication app, ITurnoService service)
        {
            app.MapGet("/turnos/{id}", (int id) => {
                var turno = service.Get(id);
                return turno is not null ? Results.Ok(turno) : Results.NotFound();
            }).WithName("GetTurno").WithOpenApi();

            app.MapGet("/turnos", () => {
                var turnos = service.GetAll();
                return Results.Ok(turnos);
            }).WithName("GetTurnos").WithOpenApi();

            app.MapPost("/turnos", ([FromBody] Turno turno) => {
                service.Add(turno);
                return Results.Created($"/turnos/{turno.Id}", turno);
            }).WithName("PostTurno").WithOpenApi();

            app.MapPut("/turnos/{id}", (int id, [FromBody] Turno turno) => {
                turno.Id = id;
                service.Update(turno);
                return Results.NoContent();
            }).WithName("PutTurno").WithOpenApi();

            app.MapDelete("/turnos/{id}", (int id) => {
                service.Delete(id);
                return Results.NoContent();
            }).WithName("DeleteTurno").WithOpenApi();
        }
    }
}