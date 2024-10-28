using Domain.Model;

namespace Domain.Services {
    public class ObraSocialService {
        private ClinicaContext _context;

        public ObraSocialService() {
            _context = new ClinicaContext();
        }

        public void Add(ObraSocial horario) {
            _context.ObrasSociales.Add(horario);
            _context.SaveChanges();
        }

        public ObraSocial? Get(int id) {
            return _context.ObrasSociales.Find(id);
        }

        public IEnumerable<ObraSocial> GetAll() {
            return _context.ObrasSociales.ToList();
        }

        public void Update(ObraSocial obra_social) {
            _context.ObrasSociales.Update(obra_social);
            _context.SaveChanges();
        }

        public void Delete(int id) {
            var obra_social = _context.ObrasSociales.Find(id);
            if (obra_social == null) return;
            _context.ObrasSociales.Remove(obra_social);
            _context.SaveChanges();
        }
    }
}
