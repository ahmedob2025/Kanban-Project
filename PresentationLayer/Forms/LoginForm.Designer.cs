using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader, pnlBody;
        private Label lblTitle, lblSubtitle, lblUsername, lblPassword;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.pnlBody = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 130;
            this.pnlHeader.BackColor = Color.FromArgb(33, 150, 243);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(100, 30);
            this.lblTitle.Text = "نظام إدارة المشاريع";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = Color.FromArgb(227, 242, 253);
            this.lblSubtitle.Location = new Point(140, 80);
            this.lblSubtitle.Text = "Kanban Project Management System";

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // pnlBody
            this.pnlBody.Dock = DockStyle.Fill;
            this.pnlBody.BackColor = Color.White;

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblUsername.ForeColor = Color.FromArgb(55, 71, 79);
            this.lblUsername.Location = new Point(60, 40);
            this.lblUsername.Text = "اسم المستخدم:";

            // txtUsername
            this.txtUsername.Font = new Font("Segoe UI", 11F);
            this.txtUsername.Location = new Point(60, 70);
            this.txtUsername.Size = new Size(340, 32);
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
            this.txtUsername.RightToLeft = RightToLeft.Yes;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblPassword.ForeColor = Color.FromArgb(55, 71, 79);
            this.lblPassword.Location = new Point(60, 120);
            this.lblPassword.Text = "كلمة المرور:";

            // txtPassword
            this.txtPassword.Font = new Font("Segoe UI", 11F);
            this.txtPassword.Location = new Point(60, 150);
            this.txtPassword.Size = new Size(340, 32);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.RightToLeft = RightToLeft.Yes;

            // btnLogin
            this.btnLogin.Location = new Point(60, 210);
            this.btnLogin.Size = new Size(340, 45);
            this.btnLogin.Text = "دخول إلى النظام";
            this.btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnLogin.BackColor = Color.FromArgb(33, 150, 243);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            this.pnlBody.Controls.Add(this.lblUsername);
            this.pnlBody.Controls.Add(this.txtUsername);
            this.pnlBody.Controls.Add(this.lblPassword);
            this.pnlBody.Controls.Add(this.txtPassword);
            this.pnlBody.Controls.Add(this.btnLogin);

            // LoginForm
            this.ClientSize = new Size(460, 420);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "تسجيل الدخول";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}