namespace Domain.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Matricula { get; set; }
        public string NroAfiliado { get; set; }
        public int Rol { get; set; }
        public Especialidad Especialidad { get; set; }
        public ObraSocial ObraSocial { get; set; }
        public ICollection<Turno> Turnos { get;}
    }
}