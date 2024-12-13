using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Domain.Interfaces;
using Domain.Model;
using Domain.Services;
using System.IO;
using WebAPI;
using Domain;

namespace UIDesktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddDbContext<ClinicaContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("DefaultConnection")))
                .AddScoped<IUsuarioService, UsuarioService>()
                .AddScoped<IEspecialidadService, EspecialidadService>()
                .AddScoped<IObraSocialService, ObraSocialService>()
                .AddScoped<IHorarioService, HorarioService>()
                .AddScoped<ITurnoService, TurnoService>()
                .BuildServiceProvider();

            var usuarioService = serviceProvider.GetRequiredService<IUsuarioService>();
            var especialidadService = serviceProvider.GetRequiredService<IEspecialidadService>();
            var obraSocialService = serviceProvider.GetRequiredService<IObraSocialService>();
            var horarioService = serviceProvider.GetRequiredService<IHorarioService>();
            var turnoService = serviceProvider.GetRequiredService<ITurnoService>();

            var loginForm = new LoginForm(usuarioService, especialidadService, obraSocialService);
            
            if (loginForm.ShowDialog() == DialogResult.OK && loginForm.UsuarioAutenticado != null)
            {
                Form mainForm;
                
                switch (loginForm.UsuarioAutenticado.Rol)
                {
                    case RolUsuario.Administrador:
                        mainForm = new AdminMainForm(usuarioService, especialidadService, obraSocialService, 
                                                  loginForm.UsuarioAutenticado);
                        break;
                    
                    case RolUsuario.Medico:
                        mainForm = new MedicoMainForm(horarioService, turnoService, 
                                                    loginForm.UsuarioAutenticado);
                        break;
                    
                    case RolUsuario.Paciente:
                        mainForm = new PacienteMainForm(turnoService, especialidadService, usuarioService,
                                                      loginForm.UsuarioAutenticado);
                        break;
                    
                    default:
                        MessageBox.Show("Rol no reconocido");
                        return;
                }

                Application.Run(mainForm);
            }
        }
    }
}
