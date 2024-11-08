using Domain.Model;

namespace Domain.Interfaces
{
    public interface ITurnoService
    {
        void Add(Turno turno);              
        Turno? Get(int id);                       
        IEnumerable<Turno> GetAll();               
        void Update(Turno turno);                
        void Delete(int id);                     
    }
}