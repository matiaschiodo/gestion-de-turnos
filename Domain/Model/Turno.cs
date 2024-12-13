namespace Domain.Model
{
    public enum EstadoTurno
    {
        Reservado,
        Cancelado,
        Completado,
        Ausente
    }

    public class Turno
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public EstadoTurno Estado { get; set; } = EstadoTurno.Reservado;
        public string? Observaciones { get; set; }

        // FKs
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }

        // Propiedades de navegación
        public Usuario Medico { get; set; }
        public Usuario Paciente { get; set; }
    }
}