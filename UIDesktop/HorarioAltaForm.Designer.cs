namespace UIDesktop
{
    partial class HorarioAltaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboDiaSemana;
        private DateTimePicker timeDesde;
        private DateTimePicker timeHasta;
        private CheckBox checkActivo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblDiaSemana;
        private Label lblHoraDesde;
        private Label lblHoraHasta;
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
            comboDiaSemana = new ComboBox();
            timeDesde = new DateTimePicker();
            timeHasta = new DateTimePicker();
            checkActivo = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lblDiaSemana = new Label();
            lblHoraDesde = new Label();
            lblHoraHasta = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();

            // TableLayoutPanel Configuration
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Padding = new Padding(10);

            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            for (int i = 0; i < 5; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            }

            // Labels
            lblDiaSemana.Text = "Día:";
            lblDiaSemana.Anchor = AnchorStyles.Left;
            lblDiaSemana.AutoSize = true;

            lblHoraDesde.Text = "Desde:";
            lblHoraDesde.Anchor = AnchorStyles.Left;
            lblHoraDesde.AutoSize = true;

            lblHoraHasta.Text = "Hasta:";
            lblHoraHasta.Anchor = AnchorStyles.Left;
            lblHoraHasta.AutoSize = true;

            // ComboBox Día
            comboDiaSemana.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboDiaSemana.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDiaSemana.Margin = new Padding(3, 5, 20, 5);

            // TimePickers
            timeDesde.Format = DateTimePickerFormat.Time;
            timeDesde.ShowUpDown = true;
            timeDesde.Anchor = AnchorStyles.Left;
            timeDesde.Width = 100;

            timeHasta.Format = DateTimePickerFormat.Time;
            timeHasta.ShowUpDown = true;
            timeHasta.Anchor = AnchorStyles.Left;
            timeHasta.Width = 100;

            // CheckBox
            checkActivo.Text = "Activo";
            checkActivo.Checked = true;
            checkActivo.Anchor = AnchorStyles.Left;

            // Buttons Panel
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
            tableLayoutPanel1.Controls.Add(lblDiaSemana, 0, 0);
            tableLayoutPanel1.Controls.Add(comboDiaSemana, 1, 0);
            tableLayoutPanel1.Controls.Add(lblHoraDesde, 0, 1);
            tableLayoutPanel1.Controls.Add(timeDesde, 1, 1);
            tableLayoutPanel1.Controls.Add(lblHoraHasta, 0, 2);
            tableLayoutPanel1.Controls.Add(timeHasta, 1, 2);
            tableLayoutPanel1.Controls.Add(checkActivo, 1, 3);
            tableLayoutPanel1.Controls.Add(buttonPanel, 1, 4);

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 250);
            this.Controls.Add(tableLayoutPanel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nuevo Horario";

            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}