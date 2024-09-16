namespace Domain.Model
{
    public class FranjaHoraria
    {
        public int Id { get; set; }
        public TimeSpan Hora_Desde { get; set; }
        public TimeSpan Hora_Hasta { get; set; }
        public Horario Horario { get; set; }
    }
}
