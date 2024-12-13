namespace UIDesktop
{
    partial class UsuarioLista
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();

            // 
            // TableLayoutPanel Configuration
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F)); // DataGridView ocupa toda la anchura
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F)); // 80% para DataGridView
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F)); // 20% para botones

            // 
            // dataGridView1
            // 
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.TabIndex = 0;

            // 
            // button1 (Agregar)
            // 
            button1.Text = "Agregar";
            button1.Size = new Size(100, 40);
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // 
            // button2 (Editar)
            // 
            button2.Text = "Editar";
            button2.Size = new Size(100, 40);
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;

            // 
            // button3 (Eliminar)
            // 
            button3.Text = "Eliminar";
            button3.Size = new Size(100, 40);
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;

            // 
            // FlowLayoutPanel for Buttons
            // 
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10), // Espaciado entre botones
                AutoSize = false,
                WrapContents = false
            };

            buttonPanel.Controls.Add(button3); // Eliminar
            buttonPanel.Controls.Add(button2); // Editar
            buttonPanel.Controls.Add(button1); // Agregar

            // 
            // Add controls to TableLayoutPanel
            // 
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonPanel, 0, 1);

            // 
            // UsuarioLista
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;

            // Tamaño y propiedades del formulario
            MinimumSize = new Size(800, 450);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;

            Controls.Add(tableLayoutPanel1);
            Name = "UsuarioLista";
            Text = "Lista de Usuarios";
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
