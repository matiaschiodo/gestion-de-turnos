using Domain.Model;

namespace Domain.Interfaces
{
    public interface IEspecialidadService
    {
        void Add(Especialidad especialidad);
        Especialidad? Get(int id);
        IEnumerable<Especialidad> GetAll();
        void Update(Especialidad especialidad);
        void Delete(int id);
    }
}
