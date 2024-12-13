using Domain.Interfaces;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class EspecialidadAlta : Form
    {
        private readonly IEspecialidadService _especialidadService;

        public EspecialidadAlta(IEspecialidadService especialidadService)
        {
            InitializeComponent();
            _especialidadService = especialidadService;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var especialidad = new Especialidad
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? 
                                 null : txtDescripcion.Text.Trim()
                };

                _especialidadService.Add(especialidad);
                
                MessageBox.Show("Especialidad agregada correctamente.", "Éxito", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la especialidad: {ex.Message}", 
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
