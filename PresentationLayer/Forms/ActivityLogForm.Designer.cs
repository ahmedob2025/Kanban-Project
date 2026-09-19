using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class ActivityLogForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop, pnlBottom, pnlCenter;
        private Label lblTitle;
        private DataGridView dgvHistory;
        private Button btnRefresh, btnClose;

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
            this.dgvHistory = new DataGridView();
            this.btnRefresh = new Button();
            this.btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.BackColor = Color.FromArgb(96, 125, 139);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "📜 سجل النشاطات";
            this.pnlTop.Controls.Add(this.lblTitle);

            // pnlBottom
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 70;
            this.pnlBottom.BackColor = Color.FromArgb(245, 245, 245);

            this.btnRefresh.Location = new Point(20, 15);
            this.btnRefresh.Size = new Size(120, 40);
            this.btnRefresh.Text = "🔄 تحديث";
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.BackColor = Color.FromArgb(33, 150, 243);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(880, 15);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Text = "إغلاق";
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnClose);

            // pnlCenter
            this.pnlCenter.Dock = DockStyle.Fill;
            this.pnlCenter.Padding = new Padding(20);
            this.pnlCenter.BackColor = Color.White;

            // dgvHistory
            this.dgvHistory.Dock = DockStyle.Fill;
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BorderStyle = BorderStyle.None;
            this.dgvHistory.BackgroundColor = Color.White;
            this.dgvHistory.GridColor = Color.FromArgb(224, 224, 224);
            this.dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHistory.RowTemplate.Height = 40;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(96, 125, 139);
            this.dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvHistory.ColumnHeadersHeight = 45;
            this.dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvHistory.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            this.dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(207, 216, 220);
            this.dgvHistory.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            this.pnlCenter.Controls.Add(this.dgvHistory);

            // ترتيب الإضافة
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);

            // النموذج
            this.ClientSize = new Size(1000, 650);
            this.MinimumSize = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "سجل النشاطات";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}