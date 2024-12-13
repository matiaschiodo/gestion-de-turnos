using Domain.Interfaces;
using Domain.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class LoginForm : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEspecialidadService _especialidadService;
        private readonly IObraSocialService _obraSocialService;
        public Usuario? UsuarioAutenticado { get; private set; }

        public LoginForm(IUsuarioService usuarioService, IEspecialidadService especialidadService, IObraSocialService obraSocialService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _especialidadService = especialidadService;
            _obraSocialService = obraSocialService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var usuario = _usuarioService.GetAll()
                    .FirstOrDefault(u => u.Email == txtEmail.Text && u.Password == txtPassword.Text);

                if (usuario == null)
                {
                    MessageBox.Show("Credenciales incorrectas.", "Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UsuarioAutenticado = usuario;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar iniciar sesión: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            var formAlta = new UsuarioAlta(_usuarioService, _especialidadService, _obraSocialService, esRegistroPublico: true);
            formAlta.ShowDialog();
        }
    }
}
