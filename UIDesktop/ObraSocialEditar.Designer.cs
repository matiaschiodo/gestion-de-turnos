namespace UIDesktop
{
    partial class ObraSocialEditar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblNombre;
        private Label lblDescripcion;
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
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lblNombre = new Label();
            lblDescripcion = new Label();

            // TableLayoutPanel
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            
            // Labels
            lblNombre.Text = "Nombre:";
            lblNombre.Anchor = AnchorStyles.Left;
            lblNombre.AutoSize = true;

            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Anchor = AnchorStyles.Left;
            lblDescripcion.AutoSize = true;

            // TextBoxes
            txtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.Margin = new Padding(3, 10, 3, 10);

            txtDescripcion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.Margin = new Padding(3, 10, 3, 10);
            txtDescripcion.Multiline = true;
            txtDescripcion.Height = 100;

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
            tableLayoutPanel1.Controls.Add(lblNombre, 0, 0);
            tableLayoutPanel1.Controls.Add(txtNombre, 1, 0);
            tableLayoutPanel1.Controls.Add(lblDescripcion, 0, 1);
            tableLayoutPanel1.Controls.Add(txtDescripcion, 1, 1);
            tableLayoutPanel1.Controls.Add(buttonPanel, 1, 2);

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 250);
            this.Controls.Add(tableLayoutPanel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Editar Obra Social";

            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}