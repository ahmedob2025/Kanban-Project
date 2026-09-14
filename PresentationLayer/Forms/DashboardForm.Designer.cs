using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop, pnlBottom;
        private TabControl tabMain;
        private TabPage tabProjects, tabMyTasks;
        private Label lblWelcome, lblSummary;
        private DataGridView dgvProjects, dgvMyTasks;
        private Button btnRefresh, btnOpenProjects, btnManageUsers, btnChangeTaskStatus, btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Panel();
            this.pnlBottom = new Panel();
            this.tabMain = new TabControl();
            this.tabProjects = new TabPage();
            this.tabMyTasks = new TabPage();
            this.lblWelcome = new Label();
            this.lblSummary = new Label();
            this.dgvProjects = new DataGridView();
            this.dgvMyTasks = new DataGridView();
            this.btnRefresh = new Button();
            this.btnOpenProjects = new Button();
            this.btnManageUsers = new Button();
            this.btnChangeTaskStatus = new Button();
            this.btnLogout = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyTasks)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabProjects.SuspendLayout();
            this.tabMyTasks.SuspendLayout();
            this.SuspendLayout();

            // ═══════════ pnlTop ═══════════
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 110;
            this.pnlTop.BackColor = Color.FromArgb(33, 150, 243);
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location = new Point(20, 20);
            this.lblWelcome.Text = "مرحباً";
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new Font("Segoe UI", 11F);
            this.lblSummary.ForeColor = Color.FromArgb(227, 242, 253);
            this.lblSummary.Location = new Point(20, 65);
            this.lblSummary.Text = "";
            this.pnlTop.Controls.Add(this.lblWelcome);
            this.pnlTop.Controls.Add(this.lblSummary);

            // ═══════════ pnlBottom ═══════════
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 70;
            this.pnlBottom.BackColor = Color.FromArgb(245, 245, 245);

            this.btnRefresh.Location = new Point(20, 15);
            this.btnRefresh.Size = new Size(110, 40);
            this.btnRefresh.Text = "🔄 تحديث";
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.BackColor = Color.FromArgb(96, 125, 139);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            this.btnOpenProjects.Location = new Point(140, 15);
            this.btnOpenProjects.Size = new Size(150, 40);
            this.btnOpenProjects.Text = "📋 إدارة المشاريع";
            this.btnOpenProjects.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnOpenProjects.BackColor = Color.FromArgb(33, 150, 243);
            this.btnOpenProjects.ForeColor = Color.White;
            this.btnOpenProjects.FlatStyle = FlatStyle.Flat;
            this.btnOpenProjects.FlatAppearance.BorderSize = 0;
            this.btnOpenProjects.Cursor = Cursors.Hand;
            this.btnOpenProjects.Click += new EventHandler(this.btnOpenProjects_Click);

            this.btnChangeTaskStatus.Location = new Point(300, 15);
            this.btnChangeTaskStatus.Size = new Size(180, 40);
            this.btnChangeTaskStatus.Text = "▶️ تغيير حالة المهمة";
            this.btnChangeTaskStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnChangeTaskStatus.BackColor = Color.FromArgb(255, 193, 7);
            this.btnChangeTaskStatus.ForeColor = Color.White;
            this.btnChangeTaskStatus.FlatStyle = FlatStyle.Flat;
            this.btnChangeTaskStatus.FlatAppearance.BorderSize = 0;
            this.btnChangeTaskStatus.Cursor = Cursors.Hand;
            this.btnChangeTaskStatus.Click += new EventHandler(this.btnChangeTaskStatus_Click);

            this.btnManageUsers.Location = new Point(490, 15);
            this.btnManageUsers.Size = new Size(160, 40);
            this.btnManageUsers.Text = "👥 إدارة المستخدمين";
            this.btnManageUsers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnManageUsers.BackColor = Color.FromArgb(76, 175, 80);
            this.btnManageUsers.ForeColor = Color.White;
            this.btnManageUsers.FlatStyle = FlatStyle.Flat;
            this.btnManageUsers.FlatAppearance.BorderSize = 0;
            this.btnManageUsers.Cursor = Cursors.Hand;
            this.btnManageUsers.Click += new EventHandler(this.btnManageUsers_Click);

            this.btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnLogout.Location = new Point(880, 15);
            this.btnLogout.Size = new Size(110, 40);
            this.btnLogout.Text = "🚪 خروج";
            this.btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLogout.BackColor = Color.FromArgb(244, 67, 54);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);

            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnOpenProjects);
            this.pnlBottom.Controls.Add(this.btnChangeTaskStatus);
            this.pnlBottom.Controls.Add(this.btnManageUsers);
            this.pnlBottom.Controls.Add(this.btnLogout);

            // ═══════════ tabMain ═══════════
            this.tabMain.Dock = DockStyle.Fill;
            this.tabMain.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.tabMain.Padding = new Point(20, 8);

            // tabProjects
            this.tabProjects.Text = "📋  المشاريع";
            this.tabProjects.BackColor = Color.White;
            this.tabProjects.Padding = new Padding(10);

            this.dgvProjects.Dock = DockStyle.Fill;
            this.dgvProjects.AllowUserToAddRows = false;
            this.dgvProjects.AllowUserToDeleteRows = false;
            this.dgvProjects.ReadOnly = true;
            this.dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjects.MultiSelect = false;
            this.dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjects.BorderStyle = BorderStyle.None;
            this.dgvProjects.BackgroundColor = Color.White;
            this.dgvProjects.GridColor = Color.FromArgb(224, 224, 224);
            this.dgvProjects.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProjects.RowTemplate.Height = 40;
            this.dgvProjects.RowHeadersVisible = false;
            this.dgvProjects.EnableHeadersVisualStyles = false;
            this.dgvProjects.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            this.dgvProjects.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvProjects.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvProjects.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProjects.ColumnHeadersHeight = 45;
            this.dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProjects.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvProjects.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            this.dgvProjects.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 222, 251);
            this.dgvProjects.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvProjects.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            this.tabProjects.Controls.Add(this.dgvProjects);

            // tabMyTasks
            this.tabMyTasks.Text = "📌  مهامي";
            this.tabMyTasks.BackColor = Color.White;
            this.tabMyTasks.Padding = new Padding(10);

            this.dgvMyTasks.Dock = DockStyle.Fill;
            this.dgvMyTasks.AllowUserToAddRows = false;
            this.dgvMyTasks.AllowUserToDeleteRows = false;
            this.dgvMyTasks.ReadOnly = true;
            this.dgvMyTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyTasks.MultiSelect = false;
            this.dgvMyTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyTasks.BorderStyle = BorderStyle.None;
            this.dgvMyTasks.BackgroundColor = Color.White;
            this.dgvMyTasks.GridColor = Color.FromArgb(224, 224, 224);
            this.dgvMyTasks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMyTasks.RowTemplate.Height = 40;
            this.dgvMyTasks.RowHeadersVisible = false;
            this.dgvMyTasks.EnableHeadersVisualStyles = false;
            this.dgvMyTasks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 152, 0);
            this.dgvMyTasks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvMyTasks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvMyTasks.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvMyTasks.ColumnHeadersHeight = 45;
            this.dgvMyTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMyTasks.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvMyTasks.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            this.dgvMyTasks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 224, 178);
            this.dgvMyTasks.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvMyTasks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            this.tabMyTasks.Controls.Add(this.dgvMyTasks);

            this.tabMain.Controls.Add(this.tabProjects);
            this.tabMain.Controls.Add(this.tabMyTasks);

            // ═══════════ DashboardForm ═══════════
            this.ClientSize = new Size(1000, 700);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new Size(800, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "لوحة المعلومات";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyTasks)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabProjects.ResumeLayout(false);
            this.tabMyTasks.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}