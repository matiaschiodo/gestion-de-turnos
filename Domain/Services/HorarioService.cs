using Domain.Interfaces;
using Domain.Model;

namespace Domain.Services
{
    public class HorarioService : IHorarioService
    {
        private readonly ClinicaContext _context;

        public HorarioService(ClinicaContext context)
        {
            _context = context;
        }

        public void Add(Horario horario)
        {
            _context.Horarios.Add(horario);
            _context.SaveChanges();
        }

        public Horario? Get(int id)
        {
            return _context.Horarios.Find(id);
        }

        public IEnumerable<Horario> GetAll()
        {
            return _context.Horarios.ToList();
        }

        public void Update(Horario horario)
        {
            _context.Horarios.Update(horario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var horario = _context.Horarios.Find(id);
            if (horario != null)
            {
                _context.Horarios.Remove(horario);
                _context.SaveChanges();
            }
        }
    }
}