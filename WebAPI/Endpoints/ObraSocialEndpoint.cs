using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints {
    public class ObraSocialEndpoint {
        public ObraSocialEndpoint(WebApplication app) {
            var service = new ObraSocialService();

            app.MapGet("/obras-sociales/{id}", (int id) => {
                return service.Get(id);
            }).WithName("GetObraSocial").WithOpenApi();

            app.MapGet("/obras-sociales", () => {
                return service.GetAll();
            }).WithName("GetObraSociales").WithOpenApi();

            app.MapPost("/obras-sociales", ([FromBody] ObraSocial obra_social) => {
                service.Add(obra_social);
            }).WithName("PostObraSocial").WithOpenApi();

            app.MapPut("/obras-sociales/{id}", ([FromBody] ObraSocial obra_social) => {
                service.Update(obra_social);
            }).WithName("PutObraSocial").WithOpenApi();

            app.MapDelete("/obras-sociales/{id}", (int id) => {
                service.Delete(id);
            }).WithName("DeleteObraSocial").WithOpenApi();
        }
    }
}
