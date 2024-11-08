namespace Domain.Model
{
    public class Horario
    {
        public int Id { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public bool Activo { get; set; }

        // FK
        public int MedicoId { get; set; }

        // Propiedad de navegación
        public Usuario Medico { get; set; }
    }
}