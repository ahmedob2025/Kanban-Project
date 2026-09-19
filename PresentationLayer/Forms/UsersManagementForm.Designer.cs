using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class UsersManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop, pnlBottom, pnlCenter, pnlSearch;
        private Label lblTitle, lblSearch;
        private DataGridView dgvUsers;
        private TextBox txtSearch;
        private Button btnAddUser, btnEditUser, btnDeactivate, btnClose;

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
            this.pnlSearch = new Panel();
            this.lblTitle = new Label();
            this.lblSearch = new Label();
            this.dgvUsers = new DataGridView();
            this.txtSearch = new TextBox();
            this.btnAddUser = new Button();
            this.btnEditUser = new Button();
            this.btnDeactivate = new Button();
            this.btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.BackColor = Color.FromArgb(33, 150, 243);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "👥 إدارة المستخدمين";
            this.pnlTop.Controls.Add(this.lblTitle);

            // pnlSearch
            this.pnlSearch.Dock = DockStyle.Top;
            this.pnlSearch.Height = 55;
            this.pnlSearch.BackColor = Color.FromArgb(250, 250, 250);
            this.pnlSearch.Padding = new Padding(20, 12, 20, 12);
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSearch.Location = new Point(20, 18);
            this.lblSearch.Text = "🔍 بحث:";
            this.txtSearch.Location = new Point(90, 15);
            this.txtSearch.Size = new Size(300, 27);
            this.txtSearch.Font = new Font("Segoe UI", 10F);
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);

            // pnlBottom
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 70;
            this.pnlBottom.BackColor = Color.FromArgb(245, 245, 245);

            this.btnAddUser.Location = new Point(20, 15);
            this.btnAddUser.Size = new Size(130, 40);
            this.btnAddUser.Text = "➕ إضافة مستخدم";
            this.btnAddUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddUser.BackColor = Color.FromArgb(76, 175, 80);
            this.btnAddUser.ForeColor = Color.White;
            this.btnAddUser.FlatStyle = FlatStyle.Flat;
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.Cursor = Cursors.Hand;
            this.btnAddUser.Click += new EventHandler(this.btnAddUser_Click);

            this.btnEditUser.Location = new Point(160, 15);
            this.btnEditUser.Size = new Size(120, 40);
            this.btnEditUser.Text = "✏️ تعديل";
            this.btnEditUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnEditUser.BackColor = Color.FromArgb(33, 150, 243);
            this.btnEditUser.ForeColor = Color.White;
            this.btnEditUser.FlatStyle = FlatStyle.Flat;
            this.btnEditUser.FlatAppearance.BorderSize = 0;
            this.btnEditUser.Cursor = Cursors.Hand;
            this.btnEditUser.Click += new EventHandler(this.btnEditUser_Click);

            this.btnDeactivate.Location = new Point(290, 15);
            this.btnDeactivate.Size = new Size(120, 40);
            this.btnDeactivate.Text = "🚫 تعطيل";
            this.btnDeactivate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDeactivate.BackColor = Color.FromArgb(255, 152, 0);
            this.btnDeactivate.ForeColor = Color.White;
            this.btnDeactivate.FlatStyle = FlatStyle.Flat;
            this.btnDeactivate.FlatAppearance.BorderSize = 0;
            this.btnDeactivate.Cursor = Cursors.Hand;
            this.btnDeactivate.Click += new EventHandler(this.btnDeactivate_Click);

            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(880, 15);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Text = "إغلاق";
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            this.pnlBottom.Controls.Add(this.btnAddUser);
            this.pnlBottom.Controls.Add(this.btnEditUser);
            this.pnlBottom.Controls.Add(this.btnDeactivate);
            this.pnlBottom.Controls.Add(this.btnClose);

            // pnlCenter
            this.pnlCenter.Dock = DockStyle.Fill;
            this.pnlCenter.Padding = new Padding(20);
            this.pnlCenter.BackColor = Color.White;

            // dgvUsers
            this.dgvUsers.Dock = DockStyle.Fill;
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BorderStyle = BorderStyle.None;
            this.dgvUsers.BackgroundColor = Color.White;
            this.dgvUsers.GridColor = Color.FromArgb(224, 224, 224);
            this.dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.RowTemplate.Height = 40;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvUsers.ColumnHeadersHeight = 45;
            this.dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvUsers.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            this.dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 222, 251);
            this.dgvUsers.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            this.pnlCenter.Controls.Add(this.dgvUsers);

            // ترتيب الإضافة
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlTop);

            // النموذج
            this.ClientSize = new Size(1000, 650);
            this.MinimumSize = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "إدارة المستخدمين";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}