namespace Domain.Model
{
    internal class UsuarioObraSocial
    {
        public int UsuarioId { get; set; }
        public int ObraSocialId { get; set; }
        public Usuario Usuario { get; set; }
        public ObraSocial ObraSocial { get; set; }
    }
}
