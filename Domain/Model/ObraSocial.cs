﻿namespace Domain.Model
{
    public class ObraSocial
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        //public List<Usuario>? Usuarios { get; set; }
    }
}