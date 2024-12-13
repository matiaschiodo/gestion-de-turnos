using Domain.Interfaces;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class PacienteMainForm : Form
    {
        private readonly ITurnoService _turnoService;
        private readonly IEspecialidadService _especialidadService;
        private readonly IUsuarioService _usuarioService;
        private readonly Usuario _usuarioActual;
        private Form? _currentForm;

        public PacienteMainForm(ITurnoService turnoService, 
                              IEspecialidadService especialidadService,
                              IUsuarioService usuarioService,
                              Usuario usuarioActual)
        {
            InitializeComponent();
            _turnoService = turnoService;
            _especialidadService = especialidadService;
            _usuarioService = usuarioService;
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
            toolStripStatusLabel1.Text = $"Paciente: {_usuarioActual.Nombre} {_usuarioActual.Apellido} - Obra Social: {_usuarioActual.ObraSocial?.Nombre}";
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

        private void solicitarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new TurnoSolicitarForm(_turnoService, _especialidadService, _usuarioService, _usuarioActual));
        }

        private void misTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new TurnosPacienteListaForm(_turnoService, _usuarioActual));
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
