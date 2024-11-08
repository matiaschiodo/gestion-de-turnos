using Domain.Model;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints
{
    public class ObraSocialEndpoint
    {
        public ObraSocialEndpoint(WebApplication app, IObraSocialService service)
        {
            app.MapGet("/obras-sociales/{id}", (int id) => {
                var obraSocial = service.Get(id);
                return obraSocial is not null ? Results.Ok(obraSocial) : Results.NotFound();
            }).WithName("GetObraSocial").WithOpenApi();

            app.MapGet("/obras-sociales", () => {
                var obrasSociales = service.GetAll();
                return Results.Ok(obrasSociales);
            }).WithName("GetObraSociales").WithOpenApi();

            app.MapPost("/obras-sociales", ([FromBody] ObraSocial obraSocial) => {
                service.Add(obraSocial);
                return Results.Created($"/obras-sociales/{obraSocial.Id}", obraSocial);
            }).WithName("PostObraSocial").WithOpenApi();

            app.MapPut("/obras-sociales/{id}", (int id, [FromBody] ObraSocial obraSocial) => {
                obraSocial.Id = id;
                service.Update(obraSocial);
                return Results.NoContent();
            }).WithName("PutObraSocial").WithOpenApi();

            app.MapDelete("/obras-sociales/{id}", (int id) => {
                service.Delete(id);
                return Results.NoContent();
            }).WithName("DeleteObraSocial").WithOpenApi();
        }
    }
}