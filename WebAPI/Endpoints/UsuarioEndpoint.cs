using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints
{
    public class UsuarioEndpoint
    {
        public UsuarioEndpoint(WebApplication app, IUsuarioService service)
        {
            app.MapGet("/usuarios/{id}", (int id) => {
                var usuario = service.Get(id);
                return usuario is not null ? Results.Ok(usuario) : Results.NotFound();
            }).WithName("GetUsuario").WithOpenApi();

            app.MapGet("/usuarios", () => {
                var usuarios = service.GetAll();
                return Results.Ok(usuarios);
            }).WithName("GetUsuarios").WithOpenApi();

            app.MapPost("/usuarios", ([FromBody] Usuario usuario) => {
                service.Add(usuario);
                return Results.Created($"/usuarios/{usuario.Id}", usuario);
            }).WithName("PostUsuario").WithOpenApi();

            app.MapPut("/usuarios/{id}", (int id, [FromBody] Usuario usuario) => {
                usuario.Id = id;
                service.Update(usuario);
                return Results.NoContent();
            }).WithName("PutUsuario").WithOpenApi();

            app.MapDelete("/usuarios/{id}", (int id) => {
                service.Delete(id);
                return Results.NoContent();
            }).WithName("DeleteUsuario").WithOpenApi();
        }
    }
}