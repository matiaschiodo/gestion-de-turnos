namespace UIDesktop
{
    partial class UsuarioAlta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private ComboBox comboBoxRol;
        private ComboBox comboBoxEspecialidad;
        private ComboBox comboBoxObraSocial;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private Label lblTelefono;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblRol;
        private Label lblEspecialidad;
        private Label lblObraSocial;
        private TableLayoutPanel tableLayoutPanel1;

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
            tableLayoutPanel1 = new TableLayoutPanel();
            
            // Inicializar controles
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            comboBoxRol = new ComboBox();
            comboBoxEspecialidad = new ComboBox();
            comboBoxObraSocial = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDni = new Label();
            lblTelefono = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            lblRol = new Label();
            lblEspecialidad = new Label();
            lblObraSocial = new Label();

            // TableLayoutPanel
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            // Labels
            lblNombre.Text = "Nombre:";
            lblNombre.Anchor = AnchorStyles.Left;
            lblNombre.AutoSize = true;

            lblApellido.Text = "Apellido:";
            lblApellido.Anchor = AnchorStyles.Left;
            lblApellido.AutoSize = true;

            lblDni.Text = "DNI:";
            lblDni.Anchor = AnchorStyles.Left;
            lblDni.AutoSize = true;

            lblTelefono.Text = "Teléfono:";
            lblTelefono.Anchor = AnchorStyles.Left;
            lblTelefono.AutoSize = true;

            lblEmail.Text = "Email:";
            lblEmail.Anchor = AnchorStyles.Left;
            lblEmail.AutoSize = true;

            lblPassword.Text = "Contraseña:";
            lblPassword.Anchor = AnchorStyles.Left;
            lblPassword.AutoSize = true;

            lblRol.Text = "Rol:";
            lblRol.Anchor = AnchorStyles.Left;
            lblRol.AutoSize = true;

            lblEspecialidad.Text = "Especialidad:";
            lblEspecialidad.Anchor = AnchorStyles.Left;
            lblEspecialidad.AutoSize = true;

            lblObraSocial.Text = "Obra Social:";
            lblObraSocial.Anchor = AnchorStyles.Left;
            lblObraSocial.AutoSize = true;

            // TextBoxes y ComboBoxes
            txtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtApellido.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDni.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTelefono.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxRol.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxEspecialidad.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxObraSocial.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Password
            txtPassword.UseSystemPasswordChar = true;

            // Buttons
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false
            };

            btnGuardar.Text = "Guardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.Click += btnCancelar_Click;

            buttonPanel.Controls.Add(btnCancelar);
            buttonPanel.Controls.Add(btnGuardar);

            // Add controls to TableLayoutPanel
            int row = 0;
            tableLayoutPanel1.Controls.Add(lblNombre, 0, row);
            tableLayoutPanel1.Controls.Add(txtNombre, 1, row++);
            tableLayoutPanel1.Controls.Add(lblApellido, 0, row);
            tableLayoutPanel1.Controls.Add(txtApellido, 1, row++);
            tableLayoutPanel1.Controls.Add(lblDni, 0, row);
            tableLayoutPanel1.Controls.Add(txtDni, 1, row++);
            tableLayoutPanel1.Controls.Add(lblTelefono, 0, row);
            tableLayoutPanel1.Controls.Add(txtTelefono, 1, row++);
            tableLayoutPanel1.Controls.Add(lblEmail, 0, row);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, row++);
            tableLayoutPanel1.Controls.Add(lblPassword, 0, row);
            tableLayoutPanel1.Controls.Add(txtPassword, 1, row++);
            tableLayoutPanel1.Controls.Add(lblRol, 0, row);
            tableLayoutPanel1.Controls.Add(comboBoxRol, 1, row++);
            tableLayoutPanel1.Controls.Add(lblEspecialidad, 0, row);
            tableLayoutPanel1.Controls.Add(comboBoxEspecialidad, 1, row++);
            tableLayoutPanel1.Controls.Add(lblObraSocial, 0, row);
            tableLayoutPanel1.Controls.Add(comboBoxObraSocial, 1, row++);
            tableLayoutPanel1.Controls.Add(buttonPanel, 1, row);

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 500);
            this.Controls.Add(tableLayoutPanel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nuevo Usuario";

            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}