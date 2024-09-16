namespace Domain.Model
{
    public class Horario
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public Usuario Profesional { get; set; }
    }
}