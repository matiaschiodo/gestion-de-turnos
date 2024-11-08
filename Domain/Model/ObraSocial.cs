namespace Domain.Model
{
    public class ObraSocial
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }

        // Propiedad de navegación
        public ICollection<Usuario> Pacientes { get; set; } = new List<Usuario>();
    }
}