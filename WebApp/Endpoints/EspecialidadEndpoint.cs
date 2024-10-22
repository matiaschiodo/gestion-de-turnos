using Domain.Model;
using Domain.Services;

namespace WebApp.EndPoints {
    public class EspecialidadEndpoint {
        public static void Map(WebApplication app) {
            var service = new EspecialidadService();

            app.MapGet("/especialidades/{id}", (int id) => {
                return service.Get(id);
            }).WithName("GetEspecialidad").WithOpenApi();

            app.MapGet("/especialidades", () => {
                return service.GetAll();
            }).WithName("GetEspecialidades").WithOpenApi();

            app.MapPost("/especialidades", (Especialidad especialidad) => {
                service.Add(especialidad);
            }).WithName("PostEspecialidad").WithOpenApi();

            app.MapPut("/especialidades/{id}", (Especialidad especialidad) => {
                service.Update(especialidad);
            }).WithName("PutEspecialidad").WithOpenApi();

            app.MapDelete("/especialidades/{id}", (int id) => {
                service.Delete(id);
            }).WithName("DeleteEspecialidad").WithOpenApi();
        }
    }
}