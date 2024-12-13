using Domain.Interfaces;
using Domain.Model;
using System;
using System.Windows.Forms;

namespace UIDesktop
{
    public partial class MedicoMainForm : Form
    {
        private readonly IHorarioService _horarioService;
        private readonly ITurnoService _turnoService;
        private readonly Usuario _usuarioActual;
        private Form? _currentForm;

        public MedicoMainForm(IHorarioService horarioService, ITurnoService turnoService, Usuario usuarioActual)
        {
            InitializeComponent();
            _horarioService = horarioService;
            _turnoService = turnoService;
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
            toolStripStatusLabel1.Text = $"Médico: {_usuarioActual.Nombre} {_usuarioActual.Apellido} - Especialidad: {_usuarioActual.Especialidad?.Nombre}";
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

        private void horariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new HorarioListaForm(_horarioService, _usuarioActual));
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new TurnosMedicoListaForm(_turnoService, _usuarioActual));
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
