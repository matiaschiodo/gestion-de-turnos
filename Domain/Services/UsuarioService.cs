using Domain.Model;

namespace Domain.Services {
    public class UsuarioService {
        private ClinicaContext _context;

        public UsuarioService() {
            _context = new ClinicaContext();
        }

        public void Add(Usuario usuario) {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario? Get(int id) {
            return _context.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> GetAll() {
            return _context.Usuarios.ToList();
        }

        public void Update(Usuario usuario) {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id) {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return;
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
