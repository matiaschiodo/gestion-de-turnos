using Domain.Interfaces;
using Domain.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class TurnosPacienteListaForm : Form
    {
        private readonly ITurnoService _turnoService;
        private readonly Usuario _usuarioActual;
        private const int HORAS_MINIMAS_CANCELACION = 24;

        public TurnosPacienteListaForm(ITurnoService turnoService, Usuario usuarioActual)
        {
            InitializeComponent();
            _turnoService = turnoService;
            _usuarioActual = usuarioActual;
            this.Load += TurnosPacienteListaForm_Load;
        }

        private void TurnosPacienteListaForm_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            ActualizarListaTurnos();
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                Visible = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                ReadOnly = true,
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Hora",
                HeaderText = "Hora",
                ReadOnly = true,
                Width = 80
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Medico",
                HeaderText = "Médico",
                ReadOnly = true,
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Especialidad",
                HeaderText = "Especialidad",
                ReadOnly = true,
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                ReadOnly = true,
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Observaciones",
                HeaderText = "Observaciones",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void ActualizarListaTurnos()
        {
            try
            {
                var turnos = _turnoService.GetAll()
                    .Where(t => t.PacienteId == _usuarioActual.Id)
                    .OrderBy(t => t.FechaHora)
                    .Select(t => new
                    {
                        t.Id,
                        Fecha = t.FechaHora.ToShortDateString(),
                        Hora = t.FechaHora.ToString("HH:mm"),
                        Medico = $"Dr. {t.Medico.Apellido}, {t.Medico.Nombre}",
                        Especialidad = t.Medico.Especialidad.Nombre,
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un turno para cancelar.", 
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedTurno = dataGridView1.SelectedRows[0].DataBoundItem as dynamic;
            if (selectedTurno == null) return;

            try
            {
                var turno = _turnoService.Get(selectedTurno.Id);
                if (turno == null) return;

                if (turno.Estado != EstadoTurno.Reservado)
                {
                    MessageBox.Show("Solo se pueden cancelar turnos que estén en estado Reservado.", 
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que la cancelación sea con al menos 24 horas de anticipación
                if (turno.FechaHora <= DateTime.Now.AddHours(HORAS_MINIMAS_CANCELACION))
                {
                    MessageBox.Show($"Los turnos deben cancelarse con al menos {HORAS_MINIMAS_CANCELACION} horas de anticipación.", 
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    "¿Está seguro que desea cancelar el turno seleccionado?",
                    "Confirmar Cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    turno.Estado = EstadoTurno.Cancelado;
                    _turnoService.Update(turno);
                    MessageBox.Show("Turno cancelado correctamente.", 
                                  "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarListaTurnos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cancelar el turno: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
