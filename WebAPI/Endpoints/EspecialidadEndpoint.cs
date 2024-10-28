using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints {
    public class EspecialidadEndpoint {
        public EspecialidadEndpoint(WebApplication app) {
            var service = new EspecialidadService();

            app.MapGet("/especialidades/{id}", (int id) => {
                return service.Get(id);
            }).WithName("GetEspecialidad").WithOpenApi();

            app.MapGet("/especialidades", () => {
                return service.GetAll();
            }).WithName("GetEspecialidades").WithOpenApi();

            app.MapPost("/especialidades", ([FromBody] Especialidad especialidad) => {
                service.Add(especialidad);
            }).WithName("PostEspecialidad").WithOpenApi();

            app.MapPut("/especialidades/{id}", ([FromBody] Especialidad especialidad) => {
                service.Update(especialidad);
            }).WithName("PutEspecialidad").WithOpenApi();

            app.MapDelete("/especialidades/{id}", (int id) => {
                service.Delete(id);
            }).WithName("DeleteEspecialidad").WithOpenApi();
        }
    }
}
