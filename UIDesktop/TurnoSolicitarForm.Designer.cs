namespace UIDesktop
{
    partial class TurnoSolicitarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboEspecialidad;
        private ComboBox comboMedico;
        private DateTimePicker dateFecha;
        private ComboBox comboHorario;
        private TextBox txtObservaciones;
        private Button btnSolicitar;
        private Button btnCancelar;
        private Label lblEspecialidad;
        private Label lblMedico;
        private Label lblFecha;
        private Label lblHorario;
        private Label lblObservaciones;
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
            comboEspecialidad = new ComboBox();
            comboMedico = new ComboBox();
            dateFecha = new DateTimePicker();
            comboHorario = new ComboBox();
            txtObservaciones = new TextBox();
            btnSolicitar = new Button();
            btnCancelar = new Button();
            lblEspecialidad = new Label();
            lblMedico = new Label();
            lblFecha = new Label();
            lblHorario = new Label();
            lblObservaciones = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();

            // TableLayoutPanel Configuration
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Padding = new Padding(10);

            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            }

            // Labels
            lblEspecialidad.Text = "Especialidad:";
            lblEspecialidad.Anchor = AnchorStyles.Left;
            lblEspecialidad.AutoSize = true;

            lblMedico.Text = "Médico:";
            lblMedico.Anchor = AnchorStyles.Left;
            lblMedico.AutoSize = true;

            lblFecha.Text = "Fecha:";
            lblFecha.Anchor = AnchorStyles.Left;
            lblFecha.AutoSize = true;

            lblHorario.Text = "Horario:";
            lblHorario.Anchor = AnchorStyles.Left;
            lblHorario.AutoSize = true;

            lblObservaciones.Text = "Observaciones:";
            lblObservaciones.Anchor = AnchorStyles.Left;
            lblObservaciones.AutoSize = true;

            // ComboBoxes
            comboEspecialidad.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEspecialidad.Margin = new Padding(3, 5, 20, 5);
            comboEspecialidad.SelectedIndexChanged += comboEspecialidad_SelectedIndexChanged;

            comboMedico.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboMedico.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMedico.Margin = new Padding(3, 5, 20, 5);
            comboMedico.SelectedIndexChanged += comboMedico_SelectedIndexChanged;

            comboHorario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboHorario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboHorario.Margin = new Padding(3, 5, 20, 5);

            // DateTimePicker
            dateFecha.Anchor = AnchorStyles.Left;
            dateFecha.Format = DateTimePickerFormat.Short;
            dateFecha.Width = 120;
            dateFecha.ValueChanged += dateFecha_ValueChanged;

            // TextBox
            txtObservaciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtObservaciones.Multiline = true;
            txtObservaciones.Height = 60;

            // Buttons Panel
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false
            };

            btnSolicitar.Text = "Solicitar";
            btnSolicitar.Size = new Size(100, 30);
            btnSolicitar.Click += btnSolicitar_Click;

            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.Click += btnCancelar_Click;

            buttonPanel.Controls.Add(btnCancelar);
            buttonPanel.Controls.Add(btnSolicitar);

            // Add controls to TableLayoutPanel
            tableLayoutPanel1.Controls.Add(lblEspecialidad, 0, 0);
            tableLayoutPanel1.Controls.Add(comboEspecialidad, 1, 0);
            tableLayoutPanel1.Controls.Add(lblMedico, 0, 1);
            tableLayoutPanel1.Controls.Add(comboMedico, 1, 1);
            tableLayoutPanel1.Controls.Add(lblFecha, 0, 2);
            tableLayoutPanel1.Controls.Add(dateFecha, 1, 2);
            tableLayoutPanel1.Controls.Add(lblHorario, 0, 3);
            tableLayoutPanel1.Controls.Add(comboHorario, 1, 3);
            tableLayoutPanel1.Controls.Add(lblObservaciones, 0, 4);
            tableLayoutPanel1.Controls.Add(txtObservaciones, 1, 4);
            tableLayoutPanel1.Controls.Add(buttonPanel, 1, 5);

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 350);
            this.Controls.Add(tableLayoutPanel1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Solicitar Turno";

            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}