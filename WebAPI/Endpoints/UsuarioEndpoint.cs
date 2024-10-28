using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.EndPoints {
    public class UsuarioEndpoint {
        public UsuarioEndpoint(WebApplication app) {
            var service = new UsuarioService();

            app.MapGet("/usuarios/{id}", (int id) => {
                return service.Get(id);
            }).WithName("GetUsuario").WithOpenApi();

            app.MapGet("/usuarios", () => {
                return service.GetAll();
            }).WithName("GetUsuarios").WithOpenApi();

            app.MapPost("/usuarios", ([FromBody] Usuario usuario) => {
                service.Add(usuario);
            }).WithName("PostUsuario").WithOpenApi();

            app.MapPut("/usuarios/{id}", ([FromBody] Usuario usuario) => {
                service.Update(usuario);
            }).WithName("PutUsuario").WithOpenApi();

            app.MapDelete("/usuarios/{id}", (int id) => {
                service.Delete(id);
            }).WithName("DeleteUsuario").WithOpenApi();
        }
    }
}
