namespace Domain.Model
{
    internal class UsuarioObraSocial
    {
        public int UsuarioId { get; set; }
        public int ObraSocialId { get; set; }
        public required Usuario Usuario { get; set; }
        public required ObraSocial ObraSocial { get; set; }
    }
}
