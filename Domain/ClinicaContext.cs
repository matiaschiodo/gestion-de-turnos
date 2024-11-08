using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ClinicaContext : DbContext
    {
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<ObraSocial> ObrasSociales { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Constructor para inyección de dependencias
        public ClinicaContext(DbContextOptions<ClinicaContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Especialidad)
                .WithMany(e => e.Medicos)
                .HasForeignKey(u => u.EspecialidadId);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.ObraSocial)
                .WithMany(o => o.Pacientes)
                .HasForeignKey(u => u.ObraSocialId);

            modelBuilder.Entity<Horario>()
                .HasOne(h => h.Medico)
                .WithMany(u => u.Horarios)
                .HasForeignKey(h => h.MedicoId);

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Medico)
                .WithMany(u => u.TurnosMedico)
                .HasForeignKey(t => t.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Paciente)
                .WithMany(u => u.TurnosPaciente)
                .HasForeignKey(t => t.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}