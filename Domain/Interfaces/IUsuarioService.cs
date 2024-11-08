using Domain.Model;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IUsuarioService
    {
        void Add(Usuario usuario);               
        Usuario? Get(int id);                        
        IEnumerable<Usuario> GetAll();                
        void Update(Usuario usuario);                 
        void Delete(int id);                         
    }
}