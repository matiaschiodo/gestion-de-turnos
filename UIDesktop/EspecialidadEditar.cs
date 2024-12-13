using Domain.Interfaces;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class EspecialidadEditar : Form
    {
        private readonly IEspecialidadService _especialidadService;
        private readonly int _especialidadId;
        private Especialidad? _especialidad;

        public EspecialidadEditar(IEspecialidadService especialidadService, int especialidadId)
        {
            InitializeComponent();
            _especialidadService = especialidadService;
            _especialidadId = especialidadId;
            this.Load += EspecialidadEditar_Load;
        }

        private void EspecialidadEditar_Load(object sender, EventArgs e)
        {
            try
            {
                _especialidad = _especialidadService.Get(_especialidadId);
                if (_especialidad != null)
                {
                    txtNombre.Text = _especialidad.Nombre;
                    txtDescripcion.Text = _especialidad.Descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la especialidad: {ex.Message}", 
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

                if (_especialidad != null)
                {
                    _especialidad.Nombre = txtNombre.Text.Trim();
                    _especialidad.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? 
                                              null : txtDescripcion.Text.Trim();

                    _especialidadService.Update(_especialidad);
                    
                    MessageBox.Show("Especialidad actualizada correctamente.", "Éxito", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la especialidad: {ex.Message}", 
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
