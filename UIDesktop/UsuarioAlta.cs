using Domain.Interfaces;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class UsuarioAlta : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEspecialidadService _especialidadService;
        private readonly IObraSocialService _obraSocialService;
        private readonly bool _esRegistroPublico;

        public UsuarioAlta(IUsuarioService usuarioService, 
                          IEspecialidadService especialidadService,
                          IObraSocialService obraSocialService,
                          bool esRegistroPublico = false)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _especialidadService = especialidadService;
            _obraSocialService = obraSocialService;
            _esRegistroPublico = esRegistroPublico;
            
            this.Load += UsuarioAlta_Load;
            comboBoxRol.SelectedIndexChanged += ComboBoxRol_SelectedIndexChanged;
        }

        private void UsuarioAlta_Load(object sender, EventArgs e)
        {
            // Cargar roles según el modo
            comboBoxRol.Items.Clear();
            if (_esRegistroPublico)
            {
                // Solo roles de Médico y Paciente para registro público
                comboBoxRol.Items.Add(RolUsuario.Medico);
                comboBoxRol.Items.Add(RolUsuario.Paciente);
            }
            else
            {
                // Todos los roles para el panel de administración
                comboBoxRol.Items.AddRange(Enum.GetValues(typeof(RolUsuario))
                                             .Cast<object>()
                                             .ToArray());
            }
            comboBoxRol.SelectedIndex = 0;

            // Cargar especialidades
            comboBoxEspecialidad.DataSource = _especialidadService.GetAll().ToList();
            comboBoxEspecialidad.DisplayMember = "Nombre";
            comboBoxEspecialidad.ValueMember = "Id";

            // Cargar obras sociales
            comboBoxObraSocial.DataSource = _obraSocialService.GetAll().ToList();
            comboBoxObraSocial.DisplayMember = "Nombre";
            comboBoxObraSocial.ValueMember = "Id";

            // Configuración inicial de visibilidad
            ActualizarVisibilidadCampos();
        }

        private void ComboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadCampos();
        }

        private void ActualizarVisibilidadCampos()
        {
            if (comboBoxRol.SelectedItem is RolUsuario rolSeleccionado)
            {
                // Mostrar/ocultar campos según el rol
                lblEspecialidad.Visible = comboBoxEspecialidad.Visible = (rolSeleccionado == RolUsuario.Medico);
                lblObraSocial.Visible = comboBoxObraSocial.Visible = (rolSeleccionado == RolUsuario.Paciente);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || 
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtDni.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var usuario = new Usuario
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = txtDni.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Rol = (RolUsuario)comboBoxRol.SelectedItem
                };

                // Asignar especialidad si es médico
                if (usuario.Rol == RolUsuario.Medico && comboBoxEspecialidad.SelectedValue is int especialidadId)
                {
                    usuario.EspecialidadId = especialidadId;
                }

                // Asignar obra social si es paciente
                if (usuario.Rol == RolUsuario.Paciente && comboBoxObraSocial.SelectedValue is int obraSocialId)
                {
                    usuario.ObraSocialId = obraSocialId;
                }

                _usuarioService.Add(usuario);
                
                MessageBox.Show("Usuario agregado correctamente.", "Éxito", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", 
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
