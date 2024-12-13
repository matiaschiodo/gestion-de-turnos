using Domain.Interfaces;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class ObraSocialAlta : Form
    {
        private readonly IObraSocialService _obraSocialService;

        public ObraSocialAlta(IObraSocialService obraSocialService)
        {
            InitializeComponent();
            _obraSocialService = obraSocialService;
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

                var obraSocial = new ObraSocial
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? 
                                 null : txtDescripcion.Text.Trim()
                };

                _obraSocialService.Add(obraSocial);
                
                MessageBox.Show("Obra social agregada correctamente.", "Éxito", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la obra social: {ex.Message}", 
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
