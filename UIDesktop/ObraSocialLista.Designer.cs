namespace UIDesktop
{
    partial class ObraSocialLista
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Button buttonAgregar;
        private Button buttonEditar;
        private Button buttonEliminar;
        private TableLayoutPanel tableLayoutPanel1;

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
            dataGridView1 = new DataGridView();
            buttonAgregar = new Button();
            buttonEditar = new Button();
            buttonEliminar = new Button();
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
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.TabIndex = 0;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            // Buttons
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10),
                AutoSize = false,
                WrapContents = false
            };

            buttonEliminar.Text = "Eliminar";
            buttonEliminar.Size = new Size(100, 40);
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;

            buttonEditar.Text = "Editar";
            buttonEditar.Size = new Size(100, 40);
            buttonEditar.UseVisualStyleBackColor = true;
            buttonEditar.Click += buttonEditar_Click;

            buttonAgregar.Text = "Agregar";
            buttonAgregar.Size = new Size(100, 40);
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;

            buttonPanel.Controls.Add(buttonEliminar);
            buttonPanel.Controls.Add(buttonEditar);
            buttonPanel.Controls.Add(buttonAgregar);

            // Add controls to TableLayoutPanel
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonPanel, 0, 1);

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(tableLayoutPanel1);
            this.Name = "ObraSocialLista";
            this.Text = "Lista de Obras Sociales";

            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            this.ResumeLayout(false);
        }
    }
}