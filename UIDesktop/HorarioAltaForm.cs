using Domain.Interfaces;
using Domain.Model;
using System;
using System.Windows.Forms;
using System.Linq;

namespace UIDesktop
{
    public partial class HorarioAltaForm : Form
    {
        private readonly IHorarioService _horarioService;
        private readonly Usuario _usuarioActual;

        public HorarioAltaForm(IHorarioService horarioService, Usuario usuarioActual)
        {
            InitializeComponent();
            _horarioService = horarioService;
            _usuarioActual = usuarioActual;
            this.Load += HorarioAltaForm_Load;
        }

        private void HorarioAltaForm_Load(object sender, EventArgs e)
        {
            // Cargar días de la semana
            comboDiaSemana.Items.Clear();
            comboDiaSemana.Items.AddRange(Enum.GetValues(typeof(DayOfWeek))
                                             .Cast<object>()
                                             .ToArray());
            comboDiaSemana.SelectedIndex = 0;

            // Configurar horarios predeterminados
            timeDesde.Value = DateTime.Today.AddHours(8); // 8:00 AM
            timeHasta.Value = DateTime.Today.AddHours(17); // 5:00 PM
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (timeHasta.Value.TimeOfDay <= timeDesde.Value.TimeOfDay)
                {
                    MessageBox.Show("La hora de finalización debe ser posterior a la hora de inicio.", 
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var horario = new Horario
                {
                    MedicoId = _usuarioActual.Id,
                    DiaSemana = (DayOfWeek)comboDiaSemana.SelectedItem,
                    HoraDesde = timeDesde.Value.TimeOfDay,
                    HoraHasta = timeHasta.Value.TimeOfDay,
                    Activo = checkActivo.Checked
                };

                // Verificar si ya existe un horario para ese día
                var horariosExistentes = _horarioService.GetAll()
                    .Where(h => h.MedicoId == _usuarioActual.Id && 
                              h.DiaSemana == horario.DiaSemana);

                if (horariosExistentes.Any())
                {
                    MessageBox.Show("Ya existe un horario configurado para ese día.", 
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _horarioService.Add(horario);
                
                MessageBox.Show("Horario agregado correctamente.", "Éxito", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el horario: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
