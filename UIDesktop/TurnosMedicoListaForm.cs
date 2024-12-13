using Domain.Interfaces;
using Domain.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class TurnosMedicoListaForm : Form
    {
        private readonly ITurnoService _turnoService;
        private readonly Usuario _usuarioActual;

        public TurnosMedicoListaForm(ITurnoService turnoService, Usuario usuarioActual)
        {
            InitializeComponent();
            _turnoService = turnoService;
            _usuarioActual = usuarioActual;
            this.Load += TurnosMedicoListaForm_Load;
        }

        private void TurnosMedicoListaForm_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarFiltroEstados();
            ActualizarListaTurnos();
        }

        private void CargarFiltroEstados()
        {
            comboFiltroEstado.Items.Add("Todos");
            comboFiltroEstado.Items.AddRange(Enum.GetValues(typeof(EstadoTurno))
                                               .Cast<object>()
                                               .ToArray());
            comboFiltroEstado.SelectedIndex = 0;
        }

        private void ConfigurarDataGridView()
        {
            // ... (código existente de configuración del DataGridView)
        }

        private void ActualizarListaTurnos()
        {
            try
            {
                var query = _turnoService.GetAll()
                    .Where(t => t.MedicoId == _usuarioActual.Id);

                // Aplicar filtro de estado
                if (comboFiltroEstado.SelectedIndex > 0) // Si no es "Todos"
                {
                    var estadoSeleccionado = (EstadoTurno)comboFiltroEstado.SelectedItem;
                    query = query.Where(t => t.Estado == estadoSeleccionado);
                }

                // Aplicar filtro de paciente
                if (!string.IsNullOrWhiteSpace(txtFiltroPaciente.Text))
                {
                    var filtroPaciente = txtFiltroPaciente.Text.ToLower();
                    query = query.Where(t => 
                        t.Paciente.Nombre.ToLower().Contains(filtroPaciente) || 
                        t.Paciente.Apellido.ToLower().Contains(filtroPaciente));
                }

                var turnos = query
                    .OrderBy(t => t.FechaHora)
                    .Select(t => new
                    {
                        t.Id,
                        Fecha = t.FechaHora.ToShortDateString(),
                        Hora = t.FechaHora.ToString("HH:mm"),
                        Paciente = $"{t.Paciente.Apellido}, {t.Paciente.Nombre}",
                        ObraSocial = t.Paciente.ObraSocial.Nombre,
                        Estado = t.Estado.ToString(),
                        t.Observaciones
                    })
                    .ToList();

                dataGridView1.DataSource = turnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de turnos: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ActualizarListaTurnos();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            comboFiltroEstado.SelectedIndex = 0;
            txtFiltroPaciente.Clear();
            ActualizarListaTurnos();
        }

        private void buttonActualizarEstado_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un turno para actualizar.", 
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedTurno = dataGridView1.SelectedRows[0].DataBoundItem as dynamic;
            if (selectedTurno == null) return;

            try
            {
                var turno = _turnoService.Get(selectedTurno.Id);
                if (turno == null) return;

                using (var formEstado = new ActualizarEstadoTurnoForm(turno.Estado))
                {
                    if (formEstado.ShowDialog() == DialogResult.OK)
                    {
                        turno.Estado = formEstado.EstadoSeleccionado;
                        _turnoService.Update(turno);
                        ActualizarListaTurnos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el estado: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
