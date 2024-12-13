using Domain.Interfaces;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class UsuarioEditar : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEspecialidadService _especialidadService;
        private readonly IObraSocialService _obraSocialService;
        private readonly int _usuarioId;
        private Usuario? _usuario;

        public UsuarioEditar(IUsuarioService usuarioService, 
                           IEspecialidadService especialidadService,
                           IObraSocialService obraSocialService,
                           int usuarioId)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _especialidadService = especialidadService;
            _obraSocialService = obraSocialService;
            _usuarioId = usuarioId;
            
            this.Load += UsuarioEditar_Load;
            comboBoxRol.SelectedIndexChanged += ComboBoxRol_SelectedIndexChanged;
        }

        private void UsuarioEditar_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar roles
                comboBoxRol.Items.Clear();
                comboBoxRol.Items.AddRange(Enum.GetValues(typeof(RolUsuario))
                                             .Cast<object>()
                                             .ToArray());

                // Cargar especialidades
                comboBoxEspecialidad.DataSource = _especialidadService.GetAll().ToList();
                comboBoxEspecialidad.DisplayMember = "Nombre";
                comboBoxEspecialidad.ValueMember = "Id";

                // Cargar obras sociales
                comboBoxObraSocial.DataSource = _obraSocialService.GetAll().ToList();
                comboBoxObraSocial.DisplayMember = "Nombre";
                comboBoxObraSocial.ValueMember = "Id";

                // Cargar datos del usuario
                _usuario = _usuarioService.Get(_usuarioId);
                if (_usuario != null)
                {
                    txtNombre.Text = _usuario.Nombre;
                    txtApellido.Text = _usuario.Apellido;
                    txtDni.Text = _usuario.Dni;
                    txtTelefono.Text = _usuario.Telefono;
                    txtEmail.Text = _usuario.Email;
                    txtPassword.Text = _usuario.Password;
                    comboBoxRol.SelectedItem = _usuario.Rol;

                    if (_usuario.EspecialidadId.HasValue)
                    {
                        comboBoxEspecialidad.SelectedValue = _usuario.EspecialidadId.Value;
                    }

                    if (_usuario.ObraSocialId.HasValue)
                    {
                        comboBoxObraSocial.SelectedValue = _usuario.ObraSocialId.Value;
                    }

                    // Configurar visibilidad inicial
                    ActualizarVisibilidadCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
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

                if (_usuario != null)
                {
                    _usuario.Nombre = txtNombre.Text.Trim();
                    _usuario.Apellido = txtApellido.Text.Trim();
                    _usuario.Dni = txtDni.Text.Trim();
                    _usuario.Telefono = txtTelefono.Text.Trim();
                    _usuario.Email = txtEmail.Text.Trim();
                    _usuario.Password = txtPassword.Text.Trim();
                    _usuario.Rol = (RolUsuario)comboBoxRol.SelectedItem;

                    // Asignar especialidad si es médico
                    _usuario.EspecialidadId = _usuario.Rol == RolUsuario.Medico && 
                                            comboBoxEspecialidad.SelectedValue is int especialidadId
                                            ? especialidadId
                                            : null;

                    // Asignar obra social si es paciente
                    _usuario.ObraSocialId = _usuario.Rol == RolUsuario.Paciente && 
                                          comboBoxObraSocial.SelectedValue is int obraSocialId
                                          ? obraSocialId
                                          : null;

                    _usuarioService.Update(_usuario);
                    
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", 
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
