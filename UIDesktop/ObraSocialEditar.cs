using Domain.Interfaces;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class ObraSocialEditar : Form
    {
        private readonly IObraSocialService _obraSocialService;
        private readonly int _obraSocialId;
        private ObraSocial? _obraSocial;

        public ObraSocialEditar(IObraSocialService obraSocialService, int obraSocialId)
        {
            InitializeComponent();
            _obraSocialService = obraSocialService;
            _obraSocialId = obraSocialId;
            this.Load += ObraSocialEditar_Load;
        }

        private void ObraSocialEditar_Load(object sender, EventArgs e)
        {
            try
            {
                _obraSocial = _obraSocialService.Get(_obraSocialId);
                if (_obraSocial != null)
                {
                    txtNombre.Text = _obraSocial.Nombre;
                    txtDescripcion.Text = _obraSocial.Descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la obra social: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
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

                if (_obraSocial != null)
                {
                    _obraSocial.Nombre = txtNombre.Text.Trim();
                    _obraSocial.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? 
                                            null : txtDescripcion.Text.Trim();

                    _obraSocialService.Update(_obraSocial);
                    
                    MessageBox.Show("Obra social actualizada correctamente.", "Éxito", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la obra social: {ex.Message}", 
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
