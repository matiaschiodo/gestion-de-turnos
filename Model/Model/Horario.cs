namespace Domain.Model
{
    public class Horario
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public List<Usuario>? Usuarios { get; set; }
    }
}
