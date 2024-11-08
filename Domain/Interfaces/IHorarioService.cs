using Domain.Model;

namespace Domain.Interfaces
{
    public interface IHorarioService
    {
        void Add(Horario horario);  
        Horario? Get(int id);                
        IEnumerable<Horario> GetAll();
        void Update(Horario horario);
        void Delete(int id);  
    }
}