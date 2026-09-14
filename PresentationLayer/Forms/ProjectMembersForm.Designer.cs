using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class ProjectMembersForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop, pnlBottom, pnlCenter, pnlRight;
        private Label lblTitle, lblAddMember;
        private DataGridView dgvMembers;
        private ComboBox cmbAvailableUsers;
        private Button btnAddMember, btnRemoveMember, btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Panel();
            this.pnlBottom = new Panel();
            this.pnlCenter = new Panel();
            this.pnlRight = new Panel();
            this.lblTitle = new Label();
            this.lblAddMember = new Label();
            this.dgvMembers = new DataGridView();
            this.cmbAvailableUsers = new ComboBox();
            this.btnAddMember = new Button();
            this.btnRemoveMember = new Button();
            this.btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.BackColor = Color.FromArgb(156, 39, 176);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "👥 أعضاء المشروع";
            this.pnlTop.Controls.Add(this.lblTitle);

            // pnlRight (إضافة عضو)
            this.pnlRight.Dock = DockStyle.Right;
            this.pnlRight.Width = 300;
            this.pnlRight.BackColor = Color.FromArgb(250, 250, 250);
            this.pnlRight.Padding = new Padding(20);

            this.lblAddMember.AutoSize = true;
            this.lblAddMember.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblAddMember.ForeColor = Color.FromArgb(55, 71, 79);
            this.lblAddMember.Location = new Point(20, 30);
            this.lblAddMember.Text = "➕ إضافة عضو جديد";

            this.cmbAvailableUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAvailableUsers.Location = new Point(20, 70);
            this.cmbAvailableUsers.Size = new Size(260, 32);
            this.cmbAvailableUsers.Font = new Font("Segoe UI", 10F);

            this.btnAddMember.Location = new Point(20, 120);
            this.btnAddMember.Size = new Size(260, 45);
            this.btnAddMember.Text = "إضافة إلى المشروع";
            this.btnAddMember.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddMember.BackColor = Color.FromArgb(76, 175, 80);
            this.btnAddMember.ForeColor = Color.White;
            this.btnAddMember.FlatStyle = FlatStyle.Flat;
            this.btnAddMember.FlatAppearance.BorderSize = 0;
            this.btnAddMember.Cursor = Cursors.Hand;
            this.btnAddMember.Click += new EventHandler(this.btnAddMember_Click);

            this.pnlRight.Controls.Add(this.lblAddMember);
            this.pnlRight.Controls.Add(this.cmbAvailableUsers);
            this.pnlRight.Controls.Add(this.btnAddMember);

            // pnlBottom
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 70;
            this.pnlBottom.BackColor = Color.FromArgb(245, 245, 245);

            this.btnRemoveMember.Location = new Point(20, 15);
            this.btnRemoveMember.Size = new Size(180, 40);
            this.btnRemoveMember.Text = "🗑️ إزالة العضو المحدد";
            this.btnRemoveMember.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRemoveMember.BackColor = Color.FromArgb(244, 67, 54);
            this.btnRemoveMember.ForeColor = Color.White;
            this.btnRemoveMember.FlatStyle = FlatStyle.Flat;
            this.btnRemoveMember.FlatAppearance.BorderSize = 0;
            this.btnRemoveMember.Cursor = Cursors.Hand;
            this.btnRemoveMember.Click += new EventHandler(this.btnRemoveMember_Click);

            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(880, 15);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Text = "إغلاق";
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            this.pnlBottom.Controls.Add(this.btnRemoveMember);
            this.pnlBottom.Controls.Add(this.btnClose);

            // pnlCenter
            this.pnlCenter.Dock = DockStyle.Fill;
            this.pnlCenter.Padding = new Padding(20);
            this.pnlCenter.BackColor = Color.White;

            // dgvMembers
            this.dgvMembers.Dock = DockStyle.Fill;
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.BorderStyle = BorderStyle.None;
            this.dgvMembers.BackgroundColor = Color.White;
            this.dgvMembers.GridColor = Color.FromArgb(224, 224, 224);
            this.dgvMembers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMembers.RowTemplate.Height = 40;
            this.dgvMembers.RowHeadersVisible = false;
            this.dgvMembers.EnableHeadersVisualStyles = false;
            this.dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(156, 39, 176);
            this.dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvMembers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvMembers.ColumnHeadersHeight = 45;
            this.dgvMembers.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvMembers.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            this.dgvMembers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 190, 231);
            this.dgvMembers.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            this.pnlCenter.Controls.Add(this.dgvMembers);

            // ترتيب الإضافة
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);

            // النموذج
            this.ClientSize = new Size(1100, 650);
            this.MinimumSize = new Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "أعضاء المشروع";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}