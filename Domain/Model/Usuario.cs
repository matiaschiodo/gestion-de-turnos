namespace Domain.Model
{
    public enum RolUsuario
    {
        Administrador = 1,
        Paciente = 2,
        Medico = 3
    }

    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Dni { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public RolUsuario Rol { get; set; }

        // FKs
        public int? EspecialidadId { get; set; }      // nullable para Paciente y Admin
        public int? ObraSocialId { get; set; }        // nullable para Médico y Admin
        public int? HorarioId { get; set; }           // nullable para Paciente y Admin

        // Propiedades de navegación
        public Especialidad? Especialidad { get; set; }
        public ObraSocial? ObraSocial { get; set; }
        public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
        public ICollection<Turno> TurnosMedico { get; set; } = new List<Turno>();
        public ICollection<Turno> TurnosPaciente { get; set; } = new List<Turno>();
    }
}