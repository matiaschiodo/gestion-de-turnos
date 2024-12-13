using Domain.Interfaces;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class AdminMainForm : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEspecialidadService _especialidadService;
        private readonly IObraSocialService _obraSocialService;
        private readonly Usuario _usuarioActual;
        private Form? _currentForm;

        public AdminMainForm(IUsuarioService usuarioService, IEspecialidadService especialidadService, 
                            IObraSocialService obraSocialService, Usuario usuarioActual)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _especialidadService = especialidadService;
            _obraSocialService = obraSocialService;
            _usuarioActual = usuarioActual;
            
            ConfigureForm();
            LoadUserInfo();
        }

        private void ConfigureForm()
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadUserInfo()
        {
            toolStripStatusLabel1.Text = $"Usuario: {_usuarioActual.Nombre} {_usuarioActual.Apellido}";
        }

        private void LoadForm(Form formToLoad)
        {
            if (_currentForm != null)
            {
                _currentForm.Close();
                panelContenedor.Controls.Remove(_currentForm);
                _currentForm.Dispose();
            }

            _currentForm = formToLoad;
            formToLoad.TopLevel = false;
            formToLoad.FormBorderStyle = FormBorderStyle.None;
            formToLoad.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formToLoad);
            formToLoad.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new UsuarioLista(_usuarioService, _especialidadService, _obraSocialService));
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new EspecialidadLista(_especialidadService));
        }

        private void obrasSocialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new ObraSocialLista(_obraSocialService));
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Confirmar", 
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
