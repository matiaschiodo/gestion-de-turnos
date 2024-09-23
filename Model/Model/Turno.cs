namespace Domain.Model
{
    public class Turno
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Estado { get; set; }
        public string? Observaciones { get; set; }
        public Usuario Paciente { get; set; }
        public Usuario Profesional { get; set; }
    }
}
