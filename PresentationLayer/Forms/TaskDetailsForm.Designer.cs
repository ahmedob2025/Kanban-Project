using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class TaskDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop, pnlBottom, pnlCenter, pnlInfo;
        private Label lblTitle, lblDescription, lblStatus, lblPriority, lblDueDate;
        private DataGridView dgvSubTasks;
        private Button btnAddSubTask, btnClose;

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
            this.pnlInfo = new Panel();
            this.lblTitle = new Label();
            this.lblDescription = new Label();
            this.lblStatus = new Label();
            this.lblPriority = new Label();
            this.lblDueDate = new Label();
            this.dgvSubTasks = new DataGridView();
            this.btnAddSubTask = new Button();
            this.btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSubTasks)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.BackColor = Color.FromArgb(255, 152, 0);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "🔍 تفاصيل المهمة";
            this.pnlTop.Controls.Add(this.lblTitle);

            // pnlInfo (بيانات المهمة)
            this.pnlInfo.Dock = DockStyle.Top;
            this.pnlInfo.Height = 220;
            this.pnlInfo.BackColor = Color.FromArgb(255, 248, 225);
            this.pnlInfo.Padding = new Padding(20);

            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new Font("Segoe UI", 11F);
            this.lblDescription.Location = new Point(20, 20);
            this.lblDescription.MaximumSize = new Size(800, 0);

            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblStatus.ForeColor = Color.FromArgb(255, 152, 0);
            this.lblStatus.Location = new Point(20, 70);

            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new Font("Segoe UI", 11F);
            this.lblPriority.Location = new Point(20, 110);

            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new Font("Segoe UI", 11F);
            this.lblDueDate.Location = new Point(20, 150);

            this.pnlInfo.Controls.Add(this.lblDescription);
            this.pnlInfo.Controls.Add(this.lblStatus);
            this.pnlInfo.Controls.Add(this.lblPriority);
            this.pnlInfo.Controls.Add(this.lblDueDate);

            // pnlBottom
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 70;
            this.pnlBottom.BackColor = Color.FromArgb(245, 245, 245);

            this.btnAddSubTask.Location = new Point(20, 15);
            this.btnAddSubTask.Size = new Size(180, 40);
            this.btnAddSubTask.Text = "➕ إضافة مهمة فرعية";
            this.btnAddSubTask.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddSubTask.BackColor = Color.FromArgb(76, 175, 80);
            this.btnAddSubTask.ForeColor = Color.White;
            this.btnAddSubTask.FlatStyle = FlatStyle.Flat;
            this.btnAddSubTask.FlatAppearance.BorderSize = 0;
            this.btnAddSubTask.Cursor = Cursors.Hand;
            this.btnAddSubTask.Click += new EventHandler(this.btnAddSubTask_Click);

            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(880, 15);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Text = "إغلاق";
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            this.pnlBottom.Controls.Add(this.btnAddSubTask);
            this.pnlBottom.Controls.Add(this.btnClose);

            // pnlCenter
            this.pnlCenter.Dock = DockStyle.Fill;
            this.pnlCenter.Padding = new Padding(20);
            this.pnlCenter.BackColor = Color.White;

            var lblSubTasksTitle = new Label
            {
                Text = "المهام الفرعية",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 35,
                ForeColor = Color.FromArgb(55, 71, 79)
            };

            // dgvSubTasks
            this.dgvSubTasks.Dock = DockStyle.Fill;
            this.dgvSubTasks.AllowUserToAddRows = false;
            this.dgvSubTasks.ReadOnly = true;
            this.dgvSubTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubTasks.BorderStyle = BorderStyle.None;
            this.dgvSubTasks.BackgroundColor = Color.White;
            this.dgvSubTasks.GridColor = Color.FromArgb(224, 224, 224);
            this.dgvSubTasks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSubTasks.RowTemplate.Height = 40;
            this.dgvSubTasks.RowHeadersVisible = false;
            this.dgvSubTasks.EnableHeadersVisualStyles = false;
            this.dgvSubTasks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 152, 0);
            this.dgvSubTasks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvSubTasks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvSubTasks.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvSubTasks.ColumnHeadersHeight = 45;
            this.dgvSubTasks.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvSubTasks.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            this.dgvSubTasks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 224, 178);
            this.dgvSubTasks.DefaultCellStyle.SelectionForeColor = Color.Black;

            this.pnlCenter.Controls.Add(this.dgvSubTasks);
            this.pnlCenter.Controls.Add(lblSubTasksTitle);

            // ترتيب الإضافة
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlTop);

            // النموذج
            this.ClientSize = new Size(1000, 650);
            this.MinimumSize = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "تفاصيل المهمة";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            ((System.ComponentModel.ISupportInitialize)(this.dgvSubTasks)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}