using Domain.Model;

namespace Domain.Services {
    public class EspecialidadService {
        private ClinicaContext _context;

        public EspecialidadService() {
            _context = new ClinicaContext();
        }

        public void Add(Especialidad especialidad) {
            _context.Especialidades.Add(especialidad);
            _context.SaveChanges();
        }

        public Especialidad? Get(int id) {
            return _context.Especialidades.Find(id);
        }

        public IEnumerable<Especialidad> GetAll() {
            return _context.Especialidades.ToList();
        }

        public void Update(Especialidad especialidad) {
            _context.Especialidades.Update(especialidad);
            _context.SaveChanges();
        }

        public void Delete(int id) {
            var especialidad = _context.Especialidades.Find(id);
            if (especialidad == null) return;
            _context.Especialidades.Remove(especialidad);
            _context.SaveChanges();
        }
    }
}
