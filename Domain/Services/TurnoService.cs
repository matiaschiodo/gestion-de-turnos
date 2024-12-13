using Domain.Interfaces;
using Domain.Model;

namespace Domain.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ClinicaContext _context;

        public TurnoService(ClinicaContext context)
        {
            _context = context;
        }

        public void Add(Turno turno)
        {
            _context.Turnos.Add(turno);
            _context.SaveChanges();
        }

        public Turno? Get(int id)
        {
            return _context.Turnos.Find(id);
        }

        public IEnumerable<Turno> GetAll()
        {
            return _context.Turnos.ToList();
        }

        public void Update(Turno turno)
        {
            _context.Turnos.Update(turno);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var turno = _context.Turnos.Find(id);
            if (turno != null)
            {
                _context.Turnos.Remove(turno);
                _context.SaveChanges();
            }
        }
    }
}