using Domain.Model;

namespace Domain.Interfaces
{
    public interface IObraSocialService
    {
        void Add(ObraSocial obraSocial);              
        ObraSocial? Get(int id);                      
        IEnumerable<ObraSocial> GetAll();              
        void Update(ObraSocial obraSocial);            
        void Delete(int id);                           
    }
}