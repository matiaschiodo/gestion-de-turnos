using Domain.Interfaces;
using Domain.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class EspecialidadLista : Form
    {
        private readonly IEspecialidadService _especialidadService;

        public EspecialidadLista(IEspecialidadService especialidadService)
        {
            InitializeComponent();
            _especialidadService = especialidadService;
            this.Load += EspecialidadLista_Load;
        }

        private void EspecialidadLista_Load(object sender, EventArgs e)
        {
            ActualizarListaEspecialidades();
        }

        private void ActualizarListaEspecialidades()
        {
            try
            {
                var especialidades = _especialidadService.GetAll().Select(e => new
                {
                    e.Id,
                    e.Nombre,
                    e.Descripcion
                }).ToList();

                dataGridView1.DataSource = especialidades;

                if (dataGridView1.Columns["Id"] != null)
                {
                    dataGridView1.Columns["Id"].Visible = false;
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de especialidades: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            var formAlta = new EspecialidadAlta(_especialidadService);
            if (formAlta.ShowDialog() == DialogResult.OK)
            {
                ActualizarListaEspecialidades();
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedEspecialidad = dataGridView1.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedEspecialidad != null)
                {
                    var formEditar = new EspecialidadEditar(_especialidadService, selectedEspecialidad.Id);
                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        ActualizarListaEspecialidades();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una especialidad para editar.", 
                               "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedEspecialidad = dataGridView1.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedEspecialidad != null)
                {
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar la especialidad '{selectedEspecialidad.Nombre}'?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            _especialidadService.Delete(selectedEspecialidad.Id);
                            ActualizarListaEspecialidades();
                            MessageBox.Show("Especialidad eliminada correctamente.", 
                                          "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (InvalidOperationException ex)
                        {
                            // Este error ocurre cuando hay médicos asociados
                            MessageBox.Show(ex.Message, "Error", 
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar la especialidad: {ex.Message}", 
                                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una especialidad para eliminar.", 
                               "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
