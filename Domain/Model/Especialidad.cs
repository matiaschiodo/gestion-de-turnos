namespace Domain.Model {
    public class Especialidad {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        //public object? Usuarios { get; internal set; }
    }
}
