using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class ProjectReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop, pnlBottom, pnlStats, pnlProgress, pnlCenter;
        private Label lblTitle, lblTotal, lblNew, lblInProgress, lblDone, lblProgress, lblPerformanceTitle;
        private ProgressBar progressBar;
        private DataGridView dgvPerformance;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Panel();
            this.pnlBottom = new Panel();
            this.pnlStats = new Panel();
            this.pnlProgress = new Panel();
            this.pnlCenter = new Panel();
            this.lblTitle = new Label();
            this.lblTotal = new Label();
            this.lblNew = new Label();
            this.lblInProgress = new Label();
            this.lblDone = new Label();
            this.lblProgress = new Label();
            this.lblPerformanceTitle = new Label();
            this.progressBar = new ProgressBar();
            this.dgvPerformance = new DataGridView();
            this.btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.BackColor = Color.FromArgb(0, 150, 136);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "📈 تقارير المشروع";
            this.pnlTop.Controls.Add(this.lblTitle);

            // pnlStats (4 بطاقات)
            this.pnlStats.Dock = DockStyle.Top;
            this.pnlStats.Height = 100;
            this.pnlStats.BackColor = Color.FromArgb(250, 250, 250);
            this.pnlStats.Padding = new Padding(20, 15, 20, 15);

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(33, 150, 243);
            this.lblTotal.Location = new Point(20, 20);
            this.lblTotal.Text = "إجمالي المهام: 0";

            this.lblNew.AutoSize = true;
            this.lblNew.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblNew.ForeColor = Color.FromArgb(96, 125, 139);
            this.lblNew.Location = new Point(250, 20);
            this.lblNew.Text = "جديدة: 0";

            this.lblInProgress.AutoSize = true;
            this.lblInProgress.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblInProgress.ForeColor = Color.FromArgb(255, 152, 0);
            this.lblInProgress.Location = new Point(450, 20);
            this.lblInProgress.Text = "قيد التنفيذ: 0";

            this.lblDone.AutoSize = true;
            this.lblDone.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblDone.ForeColor = Color.FromArgb(76, 175, 80);
            this.lblDone.Location = new Point(650, 20);
            this.lblDone.Text = "منجزة: 0";

            this.pnlStats.Controls.Add(this.lblTotal);
            this.pnlStats.Controls.Add(this.lblNew);
            this.pnlStats.Controls.Add(this.lblInProgress);
            this.pnlStats.Controls.Add(this.lblDone);

            // pnlProgress
            this.pnlProgress.Dock = DockStyle.Top;
            this.pnlProgress.Height = 90;
            this.pnlProgress.BackColor = Color.FromArgb(240, 240, 240);
            this.pnlProgress.Padding = new Padding(20, 15, 20, 15);

            var lblProgressTitle = new Label
            {
                Text = "نسبة الإنجاز:",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true,
                ForeColor = Color.FromArgb(55, 71, 79)
            };

            this.progressBar.Location = new Point(150, 22);
            this.progressBar.Size = new Size(600, 30);
            this.progressBar.Style = ProgressBarStyle.Continuous;

            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblProgress.ForeColor = Color.FromArgb(76, 175, 80);
            this.lblProgress.Location = new Point(770, 25);
            this.lblProgress.Text = "0%";

            this.pnlProgress.Controls.Add(lblProgressTitle);
            this.pnlProgress.Controls.Add(this.progressBar);
            this.pnlProgress.Controls.Add(this.lblProgress);

            // pnlCenter (أداء الفريق)
            this.pnlCenter.Dock = DockStyle.Fill;
            this.pnlCenter.Padding = new Padding(20);
            this.pnlCenter.BackColor = Color.White;

            this.lblPerformanceTitle.Dock = DockStyle.Top;
            this.lblPerformanceTitle.Height = 40;
            this.lblPerformanceTitle.Text = "🏆 أداء أعضاء الفريق";
            this.lblPerformanceTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblPerformanceTitle.ForeColor = Color.FromArgb(55, 71, 79);

            this.dgvPerformance.Dock = DockStyle.Fill;
            this.dgvPerformance.AllowUserToAddRows = false;
            this.dgvPerformance.ReadOnly = true;
            this.dgvPerformance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerformance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPerformance.BorderStyle = BorderStyle.None;
            this.dgvPerformance.BackgroundColor = Color.White;
            this.dgvPerformance.GridColor = Color.FromArgb(224, 224, 224);
            this.dgvPerformance.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPerformance.RowTemplate.Height = 40;
            this.dgvPerformance.RowHeadersVisible = false;
            this.dgvPerformance.EnableHeadersVisualStyles = false;
            this.dgvPerformance.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136);
            this.dgvPerformance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvPerformance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvPerformance.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPerformance.ColumnHeadersHeight = 45;
            this.dgvPerformance.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvPerformance.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            this.dgvPerformance.DefaultCellStyle.SelectionBackColor = Color.FromArgb(178, 223, 219);
            this.dgvPerformance.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvPerformance.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            this.pnlCenter.Controls.Add(this.dgvPerformance);
            this.pnlCenter.Controls.Add(this.lblPerformanceTitle);

            // pnlBottom
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 70;
            this.pnlBottom.BackColor = Color.FromArgb(245, 245, 245);
            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(880, 15);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Text = "إغلاق";
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.pnlBottom.Controls.Add(this.btnClose);

            // ترتيب الإضافة
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);

            // النموذج
            this.ClientSize = new Size(1000, 700);
            this.MinimumSize = new Size(800, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "تقارير المشروع";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}