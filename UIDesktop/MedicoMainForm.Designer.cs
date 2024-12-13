namespace UIDesktop
{
    partial class MedicoMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem gestionToolStripMenuItem;
        private ToolStripMenuItem horariosToolStripMenuItem;
        private ToolStripMenuItem turnosToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private Panel panelContenedor;

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
            menuStrip1 = new MenuStrip();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            gestionToolStripMenuItem = new ToolStripMenuItem();
            horariosToolStripMenuItem = new ToolStripMenuItem();
            turnosToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();

            // MenuStrip
            menuStrip1.Items.AddRange(new ToolStripItem[] {
                gestionToolStripMenuItem,
                cerrarSesiónToolStripMenuItem
            });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";

            // Gestión MenuItem
            gestionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                horariosToolStripMenuItem,
                turnosToolStripMenuItem
            });
            gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            gestionToolStripMenuItem.Text = "Gestión";

            // Horarios MenuItem
            horariosToolStripMenuItem.Name = "horariosToolStripMenuItem";
            horariosToolStripMenuItem.Text = "Mis Horarios";
            horariosToolStripMenuItem.Click += horariosToolStripMenuItem_Click;

            // Turnos MenuItem
            turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            turnosToolStripMenuItem.Text = "Mis Turnos";
            turnosToolStripMenuItem.Click += turnosToolStripMenuItem_Click;

            // Cerrar Sesión MenuItem
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;

            // StatusStrip
            statusStrip1.Items.AddRange(new ToolStripItem[] {
                toolStripStatusLabel1
            });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;

            // Panel contenedor
            panelContenedor = new Panel();
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.BackColor = SystemColors.Control;

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(panelContenedor);
            this.Controls.Add(statusStrip1);
            this.Controls.Add(menuStrip1);
            this.MainMenuStrip = menuStrip1;
            this.Name = "MedicoMainForm";
            this.Text = "Panel de Médico";
            this.WindowState = FormWindowState.Maximized;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}