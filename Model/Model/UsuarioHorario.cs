namespace Domain.Model
{
    internal class UsuarioHorario
    {
        public int UsuarioId { get; set; }
        public int HorarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Horario Horario { get; set; }
    }
}
