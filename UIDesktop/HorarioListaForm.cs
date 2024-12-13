using Domain.Interfaces;
using Domain.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class HorarioListaForm : Form
    {
        private readonly IHorarioService _horarioService;
        private readonly Usuario _usuarioActual;

        public HorarioListaForm(IHorarioService horarioService, Usuario usuarioActual)
        {
            InitializeComponent();
            _horarioService = horarioService;
            _usuarioActual = usuarioActual;
            this.Load += HorarioListaForm_Load;
        }

        private void HorarioListaForm_Load(object sender, EventArgs e)
        {
            ActualizarListaHorarios();
        }

        private void ActualizarListaHorarios()
        {
            try
            {
                var horarios = _horarioService.GetAll()
                    .Where(h => h.MedicoId == _usuarioActual.Id)
                    .Select(h => new
                    {
                        h.Id,
                        DiaSemana = h.DiaSemana.ToString(),
                        HoraDesde = h.HoraDesde.ToString(@"hh\:mm"),
                        HoraHasta = h.HoraHasta.ToString(@"hh\:mm"),
                        Estado = h.Activo ? "Activo" : "Inactivo"
                    }).ToList();

                dataGridView1.DataSource = horarios;

                if (dataGridView1.Columns["Id"] != null)
                {
                    dataGridView1.Columns["Id"].Visible = false;
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de horarios: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            var formAlta = new HorarioAltaForm(_horarioService, _usuarioActual);
            if (formAlta.ShowDialog() == DialogResult.OK)
            {
                ActualizarListaHorarios();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedHorario = dataGridView1.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedHorario != null)
                {
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar el horario seleccionado?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            _horarioService.Delete(selectedHorario.Id);
                            ActualizarListaHorarios();
                            MessageBox.Show("Horario eliminado correctamente.", 
                                          "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar el horario: {ex.Message}", 
                                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un horario para eliminar.", 
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
