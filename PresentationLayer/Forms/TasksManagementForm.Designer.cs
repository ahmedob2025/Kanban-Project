using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class TasksManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop, pnlBottom, pnlCenter;
        private Label lblTitle;
        private DataGridView dgvTasks;
        private Button btnAddTask, btnEditTask, btnDeleteTask, btnViewDetails, btnClose;
        private EventHandler btnClose_Click;

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
            this.dgvTasks = new DataGridView();
            this.btnAddTask = new Button();
            this.btnEditTask = new Button();
            this.btnDeleteTask = new Button();
            this.btnViewDetails = new Button();
            this.btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.BackColor = Color.FromArgb(255, 152, 0);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "📌 إدارة المهام";
            this.pnlTop.Controls.Add(this.lblTitle);

            // pnlBottom
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 70;
            this.pnlBottom.BackColor = Color.FromArgb(245, 245, 245);

            this.btnAddTask.Location = new Point(20, 15);
            this.btnAddTask.Size = new Size(130, 40);
            this.btnAddTask.Text = "➕ إضافة مهمة";
            this.btnAddTask.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddTask.BackColor = Color.FromArgb(76, 175, 80);
            this.btnAddTask.ForeColor = Color.White;
            this.btnAddTask.FlatStyle = FlatStyle.Flat;
            this.btnAddTask.FlatAppearance.BorderSize = 0;
            this.btnAddTask.Cursor = Cursors.Hand;
            this.btnAddTask.Click += new EventHandler(this.btnAddTask_Click);

            this.btnEditTask.Location = new Point(160, 15);
            this.btnEditTask.Size = new Size(110, 40);
            this.btnEditTask.Text = "✏️ تعديل";
            this.btnEditTask.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnEditTask.BackColor = Color.FromArgb(33, 150, 243);
            this.btnEditTask.ForeColor = Color.White;
            this.btnEditTask.FlatStyle = FlatStyle.Flat;
            this.btnEditTask.FlatAppearance.BorderSize = 0;
            this.btnEditTask.Cursor = Cursors.Hand;
            this.btnEditTask.Click += new EventHandler(this.btnEditTask_Click);

            this.btnDeleteTask.Location = new Point(280, 15);
            this.btnDeleteTask.Size = new Size(110, 40);
            this.btnDeleteTask.Text = "🗑️ حذف";
            this.btnDeleteTask.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDeleteTask.BackColor = Color.FromArgb(244, 67, 54);
            this.btnDeleteTask.ForeColor = Color.White;
            this.btnDeleteTask.FlatStyle = FlatStyle.Flat;
            this.btnDeleteTask.FlatAppearance.BorderSize = 0;
            this.btnDeleteTask.Cursor = Cursors.Hand;
            this.btnDeleteTask.Click += new EventHandler(this.btnDeleteTask_Click);

            this.btnViewDetails.Location = new Point(400, 15);
            this.btnViewDetails.Size = new Size(150, 40);
            this.btnViewDetails.Text = "🔍 عرض التفاصيل";
            this.btnViewDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnViewDetails.BackColor = Color.FromArgb(96, 125, 139);
            this.btnViewDetails.ForeColor = Color.White;
            this.btnViewDetails.FlatStyle = FlatStyle.Flat;
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.Cursor = Cursors.Hand;
            this.btnViewDetails.Click += new EventHandler(this.btnViewDetails_Click);

            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(880, 15);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Text = "إغلاق";
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
       //     this.btnClose.Click += new EventHandler(this.btnClose_Click);

            this.pnlBottom.Controls.Add(this.btnAddTask);
            this.pnlBottom.Controls.Add(this.btnEditTask);
            this.pnlBottom.Controls.Add(this.btnDeleteTask);
            this.pnlBottom.Controls.Add(this.btnViewDetails);
            this.pnlBottom.Controls.Add(this.btnClose);

            // pnlCenter
            this.pnlCenter.Dock = DockStyle.Fill;
            this.pnlCenter.Padding = new Padding(20);
            this.pnlCenter.BackColor = Color.White;

            // dgvTasks
            this.dgvTasks.Dock = DockStyle.Fill;
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.BorderStyle = BorderStyle.None;
            this.dgvTasks.BackgroundColor = Color.White;
            this.dgvTasks.GridColor = Color.FromArgb(224, 224, 224);
            this.dgvTasks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTasks.RowTemplate.Height = 40;
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.EnableHeadersVisualStyles = false;
            this.dgvTasks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 152, 0);
            this.dgvTasks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvTasks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvTasks.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTasks.ColumnHeadersHeight = 45;
            this.dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTasks.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvTasks.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            this.dgvTasks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 224, 178);
            this.dgvTasks.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvTasks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            this.pnlCenter.Controls.Add(this.dgvTasks);

            // ترتيب الإضافة
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);

            // النموذج
            this.ClientSize = new Size(1000, 650);
            this.MinimumSize = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "إدارة المهام";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}