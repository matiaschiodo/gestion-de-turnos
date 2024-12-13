namespace UIDesktop
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegistrarse;
        private Label lblEmail;
        private Label lblPassword;

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
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegistrarse = new Button();
            lblEmail = new Label();
            lblPassword = new Label();

            // Form
            this.ClientSize = new Size(400, 250);

            // TableLayoutPanel principal
            var tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(30),
                RowStyles = {
                    new RowStyle(SizeType.Absolute, 40),
                    new RowStyle(SizeType.Absolute, 40),
                    new RowStyle(SizeType.Absolute, 60)
                }
            };

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));

            // Labels
            lblEmail.Text = "Correo";
            lblEmail.Anchor = AnchorStyles.Left;
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font(lblEmail.Font.FontFamily, 10);

            lblPassword.Text = "Contraseña";
            lblPassword.Anchor = AnchorStyles.Left;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font(lblPassword.Font.FontFamily, 10);

            // TextBoxes
            txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Margin = new Padding(3, 5, 20, 5);
            txtEmail.Font = new Font(txtEmail.Font.FontFamily, 10);

            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Margin = new Padding(3, 5, 20, 5);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Font = new Font(txtPassword.Font.FontFamily, 10);

            // Buttons
            btnLogin.Text = "Iniciar";
            btnLogin.Size = new Size(100, 35);
            btnLogin.Font = new Font(btnLogin.Font.FontFamily, 10);
            btnLogin.Click += btnLogin_Click;
            btnLogin.Cursor = Cursors.Hand;

            btnRegistrarse.Text = "Crear";
            btnRegistrarse.Size = new Size(100, 35);
            btnRegistrarse.Font = new Font(btnRegistrarse.Font.FontFamily, 10);
            btnRegistrarse.Click += btnRegistrarse_Click;
            btnRegistrarse.Cursor = Cursors.Hand;

            // Buttons Panel
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0),
                WrapContents = false
            };

            buttonPanel.Controls.Add(btnRegistrarse);
            buttonPanel.Controls.Add(btnLogin);

            // Add controls to TableLayoutPanel
            tableLayoutPanel.Controls.Add(lblEmail, 0, 0);
            tableLayoutPanel.Controls.Add(txtEmail, 1, 0);
            tableLayoutPanel.Controls.Add(lblPassword, 0, 1);
            tableLayoutPanel.Controls.Add(txtPassword, 1, 1);
            tableLayoutPanel.Controls.Add(buttonPanel, 1, 2);

            // Form properties
            this.Controls.Add(tableLayoutPanel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Clínica - Inicio de Sesión";
            this.AcceptButton = btnLogin;

            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}