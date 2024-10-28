using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints {
    public class TurnoEndpoint {
        public TurnoEndpoint(WebApplication app) {
            var service = new TurnoService();

            app.MapGet("/turnos/{id}", (int id) => {
                return service.Get(id);
            }).WithName("GetTurno").WithOpenApi();

            app.MapGet("/turnos", () => {
                return service.GetAll();
            }).WithName("GetTurnos").WithOpenApi();

            app.MapPost("/turnos", ([FromBody] Turno turno) => {
                service.Add(turno);
            }).WithName("PostTurno").WithOpenApi();

            app.MapPut("/turnos/{id}", ([FromBody] Turno turno) => {
                service.Update(turno);
            }).WithName("PutTurno").WithOpenApi();

            app.MapDelete("/turnos/{id}", (int id) => {
                service.Delete(id);
            }).WithName("DeleteTurno").WithOpenApi();
        }
    }
}
