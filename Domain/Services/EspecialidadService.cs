using Domain.Model;
using Domain.Interfaces;

namespace Domain.Services
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly ClinicaContext _context;

        public EspecialidadService(ClinicaContext context)
        {
            _context = context;
        }

        public void Add(Especialidad especialidad)
        {
            if (string.IsNullOrEmpty(especialidad.Nombre))
                throw new ArgumentException("El nombre de la especialidad es requerido");

            _context.Especialidades.Add(especialidad);
            _context.SaveChanges();
        }

        public Especialidad? Get(int id)
        {
            var especialidad = _context.Especialidades.Find(id);
            if (especialidad == null)
                throw new ArgumentException($"No existe la especialidad con ID {id}");

            return especialidad;
        }

        public IEnumerable<Especialidad> GetAll()
        {
            return _context.Especialidades.ToList();
        }

        public void Update(Especialidad especialidad)
        {
            if (string.IsNullOrEmpty(especialidad.Nombre))
                throw new ArgumentException("El nombre de la especialidad es requerido");

            var existingEspecialidad = _context.Especialidades.Find(especialidad.Id);
            if (existingEspecialidad == null)
                throw new ArgumentException($"No existe la especialidad con ID {especialidad.Id}");

            _context.Especialidades.Update(especialidad);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var especialidad = _context.Especialidades.Find(id);
            if (especialidad == null)
                throw new ArgumentException($"No existe la especialidad con ID {id}");

            _context.Especialidades.Remove(especialidad);
            _context.SaveChanges();
        }
    }
}