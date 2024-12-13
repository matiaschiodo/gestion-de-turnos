using Domain.Interfaces;
using Domain.Model;
using System.Linq;

namespace UIDesktop
{
    public partial class UsuarioLista : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEspecialidadService _especialidadService;
        private readonly IObraSocialService _obraSocialService;

        public UsuarioLista(IUsuarioService usuarioService, IEspecialidadService especialidadService, IObraSocialService obraSocialService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _especialidadService = especialidadService;
            _obraSocialService = obraSocialService;

            // Ajustar el tamaño de la ventana al ancho de las columnas al cargar
            this.Load += UsuarioLista_Load;
        }

        private void UsuarioLista_Load(object sender, EventArgs e)
        {
            ActualizarListaUsuarios();
            AjustarTamañoFormulario();
        }

        private void ActualizarListaUsuarios()
        {
            try
            {
                var usuarios = _usuarioService.GetAll().Select(u => new
                {
                    u.Id,
                    u.Nombre,
                    u.Apellido,
                    u.Dni,
                    u.Telefono,
                    u.Email,
                    u.Password,
                    u.Rol,
                    Especialidad = u.Especialidad != null ? u.Especialidad.Nombre : "",
                    ObraSocial = u.ObraSocial != null ? u.ObraSocial.Nombre : ""
                }).ToList();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DataSource = usuarios;
                
                if (dataGridView1.Columns["Id"] != null)
                {
                    dataGridView1.Columns["Id"].Visible = false;
                }

                // Ajustar títulos de columnas
                if (dataGridView1.Columns["ObraSocial"] != null)
                {
                    dataGridView1.Columns["ObraSocial"].HeaderText = "Obra Social";
                }

                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjustarTamañoFormulario()
        {
            int anchoColumnas = 0;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                anchoColumnas += column.Width;
            }

            int anchoFormulario = Math.Max(anchoColumnas + 50, 1024); 
            int altoFormulario = 768; 

            this.Size = new Size(anchoFormulario, altoFormulario);
        }


        // Botón para agregar un nuevo usuario
        private void button1_Click(object sender, EventArgs e)
        {
            var formAlta = new UsuarioAlta(_usuarioService, _especialidadService, _obraSocialService);
            if (formAlta.ShowDialog() == DialogResult.OK)
            {
                ActualizarListaUsuarios();
            }
        }

        // Botón para editar un usuario seleccionado
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedUser = dataGridView1.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedUser != null)
                {
                    var formEditar = new UsuarioEditar(_usuarioService, _especialidadService, _obraSocialService, selectedUser.Id);
                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        ActualizarListaUsuarios();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Botón para eliminar un usuario seleccionado
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedUser = dataGridView1.SelectedRows[0].DataBoundItem as dynamic;
                if (selectedUser != null)
                {
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar al usuario {selectedUser.Nombre} {selectedUser.Apellido}?",
                        "Confirmación de eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            _usuarioService.Delete(selectedUser.Id);
                            ActualizarListaUsuarios();
                            MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
