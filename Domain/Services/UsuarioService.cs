using Domain.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ClinicaContext _context;

        public UsuarioService(ClinicaContext context)
        {
            _context = context;
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario? Get(int id)
        {
            return _context.Usuarios
                .Include(u => u.Especialidad)
                .Include(u => u.ObraSocial)
                .Include(u => u.Horarios)
                .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios
                .Include(u => u.Especialidad)
                .Include(u => u.ObraSocial)
                .Include(u => u.Horarios)
                .ToList();
        }

        public void Update(Usuario usuario)
        {
            var existingUsuario = _context.Usuarios.Find(usuario.Id);
            if (existingUsuario == null)
                throw new ArgumentException($"No existe el usuario con ID {usuario.Id}");

            // Desconectar la entidad existente
            _context.Entry(existingUsuario).State = EntityState.Detached;

            // Actualizar con la nueva entidad
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }
    }
}