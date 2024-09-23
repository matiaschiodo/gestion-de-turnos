using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    internal class ClinicaContext : DbContext
    {
        internal DbSet<Especialidad> Especialidades { get; set; }
        internal DbSet<Horario> Horarios { get; set; }
        internal DbSet<ObraSocial> ObrasSociales { get; set; }
        internal DbSet<Turno> Turnos { get; set; }
        internal DbSet<Usuario> Usuarios { get; set; }
        internal DbSet<UsuarioHorario> UsuariosHorarios { get; set; }
        internal DbSet<UsuarioObraSocial> UsuariosObrasSociales { get; set; }

        internal ClinicaContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=ClienteDb");

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Especialidad>()
                .HasMany(e => e.Usuarios)
                .WithOne(e => e.Especialidad)
                .HasForeigney(e => e.EspecialidadId)
        }
    }
}
