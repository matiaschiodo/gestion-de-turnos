using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints {
    public class HorarioEndpoint {
        public HorarioEndpoint(WebApplication app) {
            var service = new HorarioService();

            app.MapGet("/horarios/{id}", (int id) => {
                return service.Get(id);
            }).WithName("GetHorario").WithOpenApi();

            app.MapGet("/horarios", () => {
                return service.GetAll();
            }).WithName("GetHorarios").WithOpenApi();

            app.MapPost("/horarios", ([FromBody] Horario horario) => {
                service.Add(horario);
            }).WithName("PostHorario").WithOpenApi();

            app.MapPut("/horarios/{id}", ([FromBody] Horario horario) => {
                service.Update(horario);
            }).WithName("PutHorario").WithOpenApi();

            app.MapDelete("/horarios/{id}", (int id) => {
                service.Delete(id);
            }).WithName("DeleteHorario").WithOpenApi();
        }
    }
}
