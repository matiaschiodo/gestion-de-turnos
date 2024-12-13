namespace UIDesktop
{
    partial class TurnosPacienteListaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Button buttonCancelar;
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
            dataGridView1 = new DataGridView();
            buttonCancelar = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();

            // TableLayoutPanel Configuration
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));

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
            buttonCancelar.Text = "Cancelar Turno";
            buttonCancelar.Size = new Size(120, 35);
            buttonCancelar.Click += buttonCancelar_Click;

            buttonPanel.Controls.Add(buttonCancelar);

            // Add controls to TableLayoutPanel
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonPanel, 0, 1);

            // Form
            this.Controls.Add(tableLayoutPanel1);
            this.Size = new Size(800, 450);
            this.Text = "Mis Turnos";

            tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}