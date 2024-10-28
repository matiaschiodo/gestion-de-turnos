namespace Domain.Model {
    public class Usuario {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Dni { get; set; }
        public string? Telefono { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Matricula { get; set; }
        public string? NroAfiliado { get; set; }
        public int Rol { get; set; }
        //public Especialidad? Especialidad { get; set; }
        //public ObraSocial? ObraSocial { get; set; }
        //public List<Turno>? Turnos { get;}
        //public List<Horario>? Horarios { get; set; }
        //public List<ObraSocial>? ObrasSociales { get; set; }
    }
}
