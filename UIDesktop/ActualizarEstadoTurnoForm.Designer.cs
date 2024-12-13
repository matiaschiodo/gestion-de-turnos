namespace UIDesktop
{
    partial class ActualizarEstadoTurnoForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboEstado;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label lblEstado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboEstado = new ComboBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            lblEstado = new Label();

            // TableLayoutPanel
            var tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                Padding = new Padding(10)
            };

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));

            // Label
            lblEstado.Text = "Estado:";
            lblEstado.Anchor = AnchorStyles.Left;
            lblEstado.AutoSize = true;

            // ComboBox
            comboEstado.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEstado.Margin = new Padding(3, 5, 20, 5);

            // Buttons Panel
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false
            };

            // Buttons
            btnAceptar.Text = "Aceptar";
            btnAceptar.Size = new Size(100, 35);
            btnAceptar.Click += btnAceptar_Click;

            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.Click += btnCancelar_Click;

            buttonPanel.Controls.Add(btnCancelar);
            buttonPanel.Controls.Add(btnAceptar);

            // Add controls to TableLayoutPanel
            tableLayoutPanel.Controls.Add(lblEstado, 0, 0);
            tableLayoutPanel.Controls.Add(comboEstado, 1, 0);
            tableLayoutPanel.Controls.Add(buttonPanel, 1, 1);

            // Form
            this.ClientSize = new Size(400, 150);
            this.Controls.Add(tableLayoutPanel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Actualizar Estado";
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;

            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
} 