using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    internal class UsuarioContext : DbContext
    {
        internal DbSet<Usuario> Clientes { get; set; }
        internal DbSet<Especialidad> Especialidades { get; set; }
        internal DbSet<ObraSocial> ObrasSociales { get; set; }
        internal DbSet<Turno> Turnos { get; set; }
        internal DbSet<Horario> Horarios { get; set; }

        internal UsuarioContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=ClienteDb");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
