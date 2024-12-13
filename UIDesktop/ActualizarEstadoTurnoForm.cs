using System;
using System.Linq;
using System.Windows.Forms;
using Domain.Model;

namespace UIDesktop
{
    public partial class ActualizarEstadoTurnoForm : Form
    {
        public EstadoTurno EstadoSeleccionado { get; private set; }

        public ActualizarEstadoTurnoForm(EstadoTurno estadoActual)
        {
            InitializeComponent();
            
            comboEstado.Items.AddRange(Enum.GetValues(typeof(EstadoTurno))
                                         .Cast<object>()
                                         .ToArray());
            comboEstado.SelectedItem = estadoActual;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (comboEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estado.", 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EstadoSeleccionado = (EstadoTurno)comboEstado.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 