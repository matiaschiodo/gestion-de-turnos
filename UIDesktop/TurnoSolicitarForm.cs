using Domain.Interfaces;
using Domain.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class TurnoSolicitarForm : Form
    {
        private readonly ITurnoService _turnoService;
        private readonly IEspecialidadService _especialidadService;
        private readonly IUsuarioService _usuarioService;
        private readonly Usuario _usuarioActual;

        public TurnoSolicitarForm(ITurnoService turnoService, 
                                IEspecialidadService especialidadService,
                                IUsuarioService usuarioService,
                                Usuario usuarioActual)
        {
            InitializeComponent();
            _turnoService = turnoService;
            _especialidadService = especialidadService;
            _usuarioService = usuarioService;
            _usuarioActual = usuarioActual;

            this.Load += TurnoSolicitarForm_Load;
            ConfigurarFechaMinima();
        }

        private void TurnoSolicitarForm_Load(object sender, EventArgs e)
        {
            // Deshabilitar controles al inicio
            dateFecha.Enabled = false;
            comboHorario.Enabled = false;
            
            CargarEspecialidades();
            LimpiarCampos();
        }

        private void ConfigurarFechaMinima()
        {
            dateFecha.MinDate = DateTime.Today;
            dateFecha.MaxDate = DateTime.Today.AddMonths(3);
            dateFecha.Value = DateTime.Today;
            dateFecha.Enabled = false;
        }

        private void CargarEspecialidades()
        {
            try
            {
                var especialidades = _especialidadService.GetAll()
                    .Select(e => new { e.Id, e.Nombre })
                    .ToList();

                comboEspecialidad.DataSource = especialidades;
                comboEspecialidad.DisplayMember = "Nombre";
                comboEspecialidad.ValueMember = "Id";
                comboEspecialidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar especialidades: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Resetear y deshabilitar controles dependientes
            dateFecha.Enabled = false;
            comboHorario.Enabled = false;
            comboHorario.DataSource = null;
            
            if (comboEspecialidad.SelectedValue is int especialidadId)
            {
                CargarMedicos(especialidadId);
            }
            LimpiarSeleccionMedico();
        }

        private void CargarMedicos(int especialidadId)
        {
            try
            {
                // Primero verificamos si hay médicos para debuguear
                var todosLosMedicos = _usuarioService.GetAll().ToList();
                var medicosEspecialidad = todosLosMedicos
                    .Where(u => u.Rol == RolUsuario.Medico && 
                               u.EspecialidadId == especialidadId)
                    .ToList();

                if (!medicosEspecialidad.Any())
                {
                    MessageBox.Show("No hay médicos disponibles para esta especialidad.", 
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Verificamos los horarios
                var medicosConHorarios = medicosEspecialidad
                    .Where(m => m.Horarios != null && m.Horarios.Any(h => h.Activo))
                    .Select(m => new 
                    { 
                        m.Id, 
                        NombreCompleto = $"{m.Nombre} {m.Apellido}"  // Cambiamos el orden a Nombre Apellido
                    })
                    .OrderBy(m => m.NombreCompleto)
                    .ToList();

                if (!medicosConHorarios.Any())
                {
                    MessageBox.Show("No hay médicos con horarios disponibles para esta especialidad.", 
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                comboMedico.DataSource = medicosConHorarios;
                comboMedico.DisplayMember = "NombreCompleto";
                comboMedico.ValueMember = "Id";
                comboMedico.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar médicos: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboHorario.DataSource = null;
            comboHorario.Enabled = false;

            if (comboMedico.SelectedValue is int medicoId)
            {
                var medico = _usuarioService.Get(medicoId);
                if (medico != null && medico.Horarios.Any(h => h.Activo))
                {
                    dateFecha.Enabled = true;
                    // Cargar solo los días que el médico atiende
                    CargarDiasDisponibles(medico);
                }
                else
                {
                    MessageBox.Show("El médico seleccionado no tiene horarios disponibles.", 
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CargarDiasDisponibles(Usuario medico)
        {
            // Obtener los días que atiende el médico
            var diasAtencion = medico.Horarios
                .Where(h => h.Activo)
                .Select(h => h.DiaSemana)
                .ToList();

            if (!diasAtencion.Any())
            {
                MessageBox.Show("El médico no tiene días de atención configurados.", 
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Configurar el DateTimePicker
            dateFecha.MinDate = DateTime.Today;
            dateFecha.MaxDate = DateTime.Today.AddMonths(3);
            dateFecha.Value = DateTime.Today;
            
            // Buscar el próximo día disponible
            var fecha = DateTime.Today;
            while (!diasAtencion.Contains(fecha.DayOfWeek))
            {
                fecha = fecha.AddDays(1);
            }
            dateFecha.Value = fecha;
            
            comboHorario.Enabled = true;
            ActualizarHorariosDisponibles();
        }

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {
            if (comboMedico.SelectedValue is int medicoId)
            {
                var medico = _usuarioService.Get(medicoId);
                if (medico != null)
                {
                    var diaSeleccionado = dateFecha.Value.DayOfWeek;
                    if (!medico.Horarios.Any(h => h.DiaSemana == diaSeleccionado && h.Activo))
                    {
                        MessageBox.Show("El médico no atiende este día. Por favor seleccione otro día.", 
                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ActualizarHorariosDisponibles();
                }
            }
        }

        private void ActualizarHorariosDisponibles()
        {
            comboHorario.DataSource = null;
            
            if (!(comboMedico.SelectedValue is int medicoId))
            {
                return;
            }

            try
            {
                var medico = _usuarioService.Get(medicoId);
                if (medico == null) return;

                var diaSeleccionado = dateFecha.Value.DayOfWeek;
                var horarioMedico = medico.Horarios
                    .FirstOrDefault(h => h.DiaSemana == diaSeleccionado && h.Activo);

                if (horarioMedico == null)
                {
                    MessageBox.Show("El médico no atiende este día.", 
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboHorario.DataSource = null;
                    return;
                }

                // Obtener turnos ya reservados para ese día
                var turnosExistentes = _turnoService.GetAll()
                    .Where(t => t.MedicoId == medicoId &&
                               t.FechaHora.Date == dateFecha.Value.Date &&
                               t.Estado == EstadoTurno.Reservado)
                    .Select(t => t.FechaHora.TimeOfDay)
                    .ToList();

                // Generar horarios disponibles cada 30 minutos
                var horariosDisponibles = new List<TimeSpan>();
                var horaActual = horarioMedico.HoraDesde;

                while (horaActual <= horarioMedico.HoraHasta.Add(TimeSpan.FromMinutes(-30)))
                {
                    if (!turnosExistentes.Contains(horaActual))
                    {
                        horariosDisponibles.Add(horaActual);
                    }
                    horaActual = horaActual.Add(TimeSpan.FromMinutes(30));
                }

                if (!horariosDisponibles.Any())
                {
                    MessageBox.Show("No hay horarios disponibles para este día.", 
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                comboHorario.DataSource = horariosDisponibles;
                comboHorario.Format += (s, e) => 
                {
                    if (e.Value is TimeSpan ts)
                    {
                        e.Value = ts.ToString(@"hh\:mm");
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar horarios disponibles: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            comboMedico.DataSource = null;
            comboHorario.DataSource = null;
            txtObservaciones.Clear();
        }

        private void LimpiarSeleccionMedico()
        {
            comboMedico.SelectedIndex = -1;
            comboHorario.DataSource = null;
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                var horario = (TimeSpan)comboHorario.SelectedItem;
                var fechaHora = dateFecha.Value.Date.Add(horario);

                var turno = new Turno
                {
                    MedicoId = (int)comboMedico.SelectedValue,
                    PacienteId = _usuarioActual.Id,
                    FechaHora = fechaHora,
                    Estado = EstadoTurno.Reservado,
                    Observaciones = txtObservaciones.Text.Trim()
                };

                _turnoService.Add(turno);
                
                MessageBox.Show("Turno reservado correctamente.", "Éxito", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reservar el turno: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (comboEspecialidad.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una especialidad.", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboMedico.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un médico.", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboHorario.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un horario.", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
