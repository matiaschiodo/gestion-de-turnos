using Domain.Interfaces;
using Domain.Model;

namespace Domain.Services
{
    public class ObraSocialService : IObraSocialService
    {
        private readonly ClinicaContext _context;

        public ObraSocialService(ClinicaContext context)
        {
            _context = context;
        }

        public void Add(ObraSocial obraSocial)
        {
            _context.ObrasSociales.Add(obraSocial);
            _context.SaveChanges();
        }

        public ObraSocial? Get(int id)
        {
            return _context.ObrasSociales.Find(id);
        }

        public IEnumerable<ObraSocial> GetAll()
        {
            return _context.ObrasSociales.ToList();
        }

        public void Update(ObraSocial obraSocial)
        {
            _context.ObrasSociales.Update(obraSocial);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var obraSocial = _context.ObrasSociales.Find(id);
            if (obraSocial != null)
            {
                _context.ObrasSociales.Remove(obraSocial);
                _context.SaveChanges();
            }
        }
    }
}