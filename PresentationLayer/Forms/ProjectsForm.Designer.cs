using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class ProjectsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop, pnlBottom, pnlCenter;
        private Label lblTitle;
        private DataGridView dgvProjects;
        private Button btnNewProject, btnEditProject, btnManageTasks, btnMembers, btnOpenBoard, btnReports, btnClose;

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
            this.lblTitle = new Label();
            this.dgvProjects = new DataGridView();
            this.btnNewProject = new Button();
            this.btnEditProject = new Button();
            this.btnManageTasks = new Button();
            this.btnMembers = new Button();
            this.btnOpenBoard = new Button();
            this.btnReports = new Button();
            this.btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.BackColor = Color.FromArgb(33, 150, 243);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "📋 إدارة المشاريع";
            this.pnlTop.Controls.Add(this.lblTitle);

            // pnlBottom
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 70;
            this.pnlBottom.BackColor = Color.FromArgb(245, 245, 245);

            this.btnNewProject.Location = new Point(20, 15);
            this.btnNewProject.Size = new Size(130, 40);
            this.btnNewProject.Text = "➕ مشروع جديد";
            this.btnNewProject.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnNewProject.BackColor = Color.FromArgb(76, 175, 80);
            this.btnNewProject.ForeColor = Color.White;
            this.btnNewProject.FlatStyle = FlatStyle.Flat;
            this.btnNewProject.FlatAppearance.BorderSize = 0;
            this.btnNewProject.Cursor = Cursors.Hand;
            this.btnNewProject.Click += new EventHandler(this.btnNewProject_Click);

            this.btnEditProject.Location = new Point(160, 15);
            this.btnEditProject.Size = new Size(110, 40);
            this.btnEditProject.Text = "✏️ تعديل";
            this.btnEditProject.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnEditProject.Click += new EventHandler(this.btnEditProject_Click);

            this.btnManageTasks.Location = new Point(280, 15);
            this.btnManageTasks.Size = new Size(140, 40);
            this.btnManageTasks.Text = "📌 إدارة المهام";
            this.btnManageTasks.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnManageTasks.BackColor = Color.FromArgb(255, 152, 0);
            this.btnManageTasks.ForeColor = Color.White;
            this.btnManageTasks.FlatStyle = FlatStyle.Flat;
            this.btnManageTasks.FlatAppearance.BorderSize = 0;
            this.btnManageTasks.Cursor = Cursors.Hand;
            this.btnManageTasks.Click += new EventHandler(this.btnManageTasks_Click);

            this.btnMembers.Location = new Point(430, 15);
            this.btnMembers.Size = new Size(140, 40);
            this.btnMembers.Text = "👥 الأعضاء";
            this.btnMembers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnMembers.Click += new EventHandler(this.btnMembers_Click);

            this.btnOpenBoard.Location = new Point(580, 15);
            this.btnOpenBoard.Size = new Size(130, 40);
            this.btnOpenBoard.Text = "📊 كانبان";
            this.btnOpenBoard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnOpenBoard.BackColor = Color.FromArgb(156, 39, 176);
            this.btnOpenBoard.ForeColor = Color.White;
            this.btnOpenBoard.FlatStyle = FlatStyle.Flat;
            this.btnOpenBoard.FlatAppearance.BorderSize = 0;
            this.btnOpenBoard.Cursor = Cursors.Hand;
            this.btnOpenBoard.Click += new EventHandler(this.btnOpenBoard_Click);

            this.btnReports.Location = new Point(720, 15);
            this.btnReports.Size = new Size(130, 40);
            this.btnReports.Text = "📈 التقارير";
            this.btnReports.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnReports.BackColor = Color.FromArgb(0, 150, 136);
            this.btnReports.ForeColor = Color.White;
            this.btnReports.FlatStyle = FlatStyle.Flat;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.Cursor = Cursors.Hand;
            this.btnReports.Click += new EventHandler(this.btnReports_Click);

            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(880, 15);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Text = "إغلاق";
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            this.pnlBottom.Controls.Add(this.btnNewProject);
            this.pnlBottom.Controls.Add(this.btnEditProject);
            this.pnlBottom.Controls.Add(this.btnManageTasks);
            this.pnlBottom.Controls.Add(this.btnMembers);
            this.pnlBottom.Controls.Add(this.btnOpenBoard);
            this.pnlBottom.Controls.Add(this.btnReports);
            this.pnlBottom.Controls.Add(this.btnClose);

            // pnlCenter
            this.pnlCenter.Dock = DockStyle.Fill;
            this.pnlCenter.Padding = new Padding(20);
            this.pnlCenter.BackColor = Color.White;

            // dgvProjects
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

            this.pnlCenter.Controls.Add(this.dgvProjects);

            // ترتيب الإضافة
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);

            // النموذج
            this.ClientSize = new Size(1000, 650);
            this.MinimumSize = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "المشاريع";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}