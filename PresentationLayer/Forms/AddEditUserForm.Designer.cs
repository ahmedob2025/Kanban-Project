using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class AddEditUserForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblFullName;
        private Label lblEmail;
        private Label lblRole;
        private Label lblPasswordNote;

        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private ComboBox cmbRole;
        private CheckBox chkIsActive;

        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.lblFullName = new Label();
            this.lblEmail = new Label();
            this.lblRole = new Label();
            this.lblPasswordNote = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.txtFullName = new TextBox();
            this.txtEmail = new TextBox();
            this.cmbRole = new ComboBox();
            this.chkIsActive = new CheckBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(33, 150, 243);
            this.lblTitle.Location = new Point(100, 20);
            this.lblTitle.Text = "إضافة مستخدم جديد";

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new Point(30, 80);
            this.lblUsername.Text = "اسم المستخدم:";

            // txtUsername
            this.txtUsername.Location = new Point(150, 77);
            this.txtUsername.Size = new Size(250, 27);

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(30, 125);
            this.lblPassword.Text = "كلمة المرور:";

            // txtPassword
            this.txtPassword.Location = new Point(150, 122);
            this.txtPassword.Size = new Size(250, 27);
            this.txtPassword.UseSystemPasswordChar = true;

            // lblPasswordNote
            this.lblPasswordNote.AutoSize = true;
            this.lblPasswordNote.ForeColor = Color.Gray;
            this.lblPasswordNote.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblPasswordNote.Location = new Point(150, 150);
            this.lblPasswordNote.Text = "(لا يمكن تعديل كلمة المرور من هنا)";
            this.lblPasswordNote.Visible = false;

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new Point(30, 180);
            this.lblFullName.Text = "الاسم الكامل:";

            // txtFullName
            this.txtFullName.Location = new Point(150, 177);
            this.txtFullName.Size = new Size(250, 27);

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(30, 225);
            this.lblEmail.Text = "البريد الإلكتروني:";

            // txtEmail
            this.txtEmail.Location = new Point(150, 222);
            this.txtEmail.Size = new Size(250, 27);

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new Point(30, 270);
            this.lblRole.Text = "الدور:";

            // cmbRole
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new Point(150, 267);
            this.cmbRole.Size = new Size(250, 28);

            // chkIsActive
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new Point(150, 310);
            this.chkIsActive.Text = "الحساب نشط";
            this.chkIsActive.Checked = true;

            // btnSave
            this.btnSave.BackColor = Color.FromArgb(33, 150, 243);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Location = new Point(150, 350);
            this.btnSave.Size = new Size(120, 40);
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new Point(280, 350);
            this.btnCancel.Size = new Size(120, 40);
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // AddEditUserForm
            this.ClientSize = new Size(440, 420);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPasswordNote);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "إضافة مستخدم";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}