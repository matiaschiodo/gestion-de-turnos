using Domain.Interfaces;
using Domain.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class ObraSocialLista : Form
    {
        private readonly IObraSocialService _obraSocialService;

        public ObraSocialLista(IObraSocialService obraSocialService)
        {
            InitializeComponent();
            _obraSocialService = obraSocialService;
            this.Load += ObraSocialLista_Load;
        }

        private void ObraSocialLista_Load(object sender, EventArgs e)
        {
            ActualizarListaObrasSociales();
        }

        private void ActualizarListaObrasSociales()
        {
            try
            {
                var obrasSociales = _obraSocialService.GetAll().Select(o => new
                {
                    o.Id,
                    o.Nombre,
                    o.Descripcion
                }).ToList();

                dataGridView1.DataSource = obrasSociales;

                if (dataGridView1.Columns["Id"] != null)
                {
                    dataGridView1.Columns["Id"].Visible = false;
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de obras sociales: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            var formAlta = new ObraSocialAlta(_obraSocialService);
            if (formAlta.ShowDialog() == DialogResult.OK)
            {
                ActualizarListaObrasSociales();
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedObraSocial = dataGridView1.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedObraSocial != null)
                {
                    var formEditar = new ObraSocialEditar(_obraSocialService, selectedObraSocial.Id);
                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        ActualizarListaObrasSociales();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una obra social para editar.", 
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedObraSocial = dataGridView1.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedObraSocial != null)
                {
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar la obra social '{selectedObraSocial.Nombre}'?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            _obraSocialService.Delete(selectedObraSocial.Id);
                            ActualizarListaObrasSociales();
                            MessageBox.Show("Obra social eliminada correctamente.", 
                                          "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", 
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar la obra social: {ex.Message}", 
                                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una obra social para eliminar.", 
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
