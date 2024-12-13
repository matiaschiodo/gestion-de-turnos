namespace UIDesktop
{
    partial class TurnosMedicoListaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Button buttonActualizarEstado;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox comboFiltroEstado;
        private TextBox txtFiltroPaciente;
        private Label lblFiltroEstado;
        private Label lblFiltroPaciente;
        private Button btnFiltrar;
        private Button btnLimpiarFiltros;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Inicializar controles
            dataGridView1 = new DataGridView();
            buttonActualizarEstado = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            comboFiltroEstado = new ComboBox();
            txtFiltroPaciente = new TextBox();
            lblFiltroEstado = new Label();
            lblFiltroPaciente = new Label();
            btnFiltrar = new Button();
            btnLimpiarFiltros = new Button();

            // Panel de Filtros
            var panelFiltros = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 5,
                RowCount = 1,
                Height = 40,
                Padding = new Padding(5)
            };

            // Labels
            lblFiltroEstado.Text = "Estado:";
            lblFiltroEstado.Anchor = AnchorStyles.Left;
            lblFiltroEstado.AutoSize = true;

            lblFiltroPaciente.Text = "Paciente:";
            lblFiltroPaciente.Anchor = AnchorStyles.Left;
            lblFiltroPaciente.AutoSize = true;

            // ComboBox Estado
            comboFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFiltroEstado.Width = 150;

            // TextBox Paciente
            txtFiltroPaciente.Width = 150;

            // Botones de filtro
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Size = new Size(80, 30);
            btnFiltrar.Click += btnFiltrar_Click;

            btnLimpiarFiltros.Text = "Limpiar";
            btnLimpiarFiltros.Size = new Size(80, 30);
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;

            // Agregar controles al panel de filtros
            panelFiltros.Controls.Add(lblFiltroEstado, 0, 0);
            panelFiltros.Controls.Add(comboFiltroEstado, 1, 0);
            panelFiltros.Controls.Add(lblFiltroPaciente, 2, 0);
            panelFiltros.Controls.Add(txtFiltroPaciente, 3, 0);
            panelFiltros.Controls.Add(btnFiltrar, 4, 0);
            panelFiltros.Controls.Add(btnLimpiarFiltros, 5, 0);

            // TableLayoutPanel Configuration
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            // DataGridView
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Buttons Panel
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10),
                WrapContents = false
            };

            // Button
            buttonActualizarEstado.Text = "Actualizar Estado";
            buttonActualizarEstado.Size = new Size(120, 35);
            buttonActualizarEstado.Click += buttonActualizarEstado_Click;

            buttonPanel.Controls.Add(buttonActualizarEstado);

            // Add controls to TableLayoutPanel
            tableLayoutPanel1.Controls.Add(panelFiltros, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonPanel, 0, 2);

            // Form
            this.Controls.Add(tableLayoutPanel1);
            this.Size = new Size(1000, 600);
            this.Text = "Gestión de Turnos";

            tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}