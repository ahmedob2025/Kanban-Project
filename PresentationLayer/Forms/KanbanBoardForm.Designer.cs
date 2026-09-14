using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class KanbanBoardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop, pnlBottom, pnlBoard;
        private Label lblTitle;
        private Panel pnlNew, pnlInProgress, pnlDone;
        private Label lblNewTitle, lblInProgressTitle, lblDoneTitle;
        private FlowLayoutPanel flowNew, flowInProgress, flowDone;
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
            this.pnlBoard = new Panel();
            this.lblTitle = new Label();
            this.pnlNew = new Panel();
            this.pnlInProgress = new Panel();
            this.pnlDone = new Panel();
            this.lblNewTitle = new Label();
            this.lblInProgressTitle = new Label();
            this.lblDoneTitle = new Label();
            this.flowNew = new FlowLayoutPanel();
            this.flowInProgress = new FlowLayoutPanel();
            this.flowDone = new FlowLayoutPanel();
            this.btnClose = new Button();

            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBoard.SuspendLayout();
            this.pnlNew.SuspendLayout();
            this.pnlInProgress.SuspendLayout();
            this.pnlDone.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.BackColor = Color.FromArgb(156, 39, 176);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "📊 لوحة كانبان";
            this.pnlTop.Controls.Add(this.lblTitle);

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

            // pnlBoard
            this.pnlBoard.Dock = DockStyle.Fill;
            this.pnlBoard.Padding = new Padding(20);
            this.pnlBoard.BackColor = Color.FromArgb(240, 240, 240);

            // pnlNew
            this.pnlNew.Dock = DockStyle.Left;
            this.pnlNew.Width = 300;
            this.pnlNew.Padding = new Padding(5);
            this.pnlNew.BackColor = Color.White;

            this.lblNewTitle.Dock = DockStyle.Top;
            this.lblNewTitle.Height = 45;
            this.lblNewTitle.Text = "🆕 جديد";
            this.lblNewTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblNewTitle.ForeColor = Color.White;
            this.lblNewTitle.BackColor = Color.FromArgb(33, 150, 243);
            this.lblNewTitle.TextAlign = ContentAlignment.MiddleCenter;

            this.flowNew.Dock = DockStyle.Fill;
            this.flowNew.AutoScroll = true;
            this.flowNew.FlowDirection = FlowDirection.TopDown;
            this.flowNew.WrapContents = false;
            this.flowNew.BackColor = Color.FromArgb(245, 245, 245);
            this.flowNew.Padding = new Padding(5);

            this.pnlNew.Controls.Add(this.flowNew);
            this.pnlNew.Controls.Add(this.lblNewTitle);

            // pnlInProgress
            this.pnlInProgress.Dock = DockStyle.Left;
            this.pnlInProgress.Width = 300;
            this.pnlInProgress.Padding = new Padding(5);
            this.pnlInProgress.BackColor = Color.White;

            this.lblInProgressTitle.Dock = DockStyle.Top;
            this.lblInProgressTitle.Height = 45;
            this.lblInProgressTitle.Text = "⚙️ قيد التنفيذ";
            this.lblInProgressTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblInProgressTitle.ForeColor = Color.White;
            this.lblInProgressTitle.BackColor = Color.FromArgb(255, 152, 0);
            this.lblInProgressTitle.TextAlign = ContentAlignment.MiddleCenter;

            this.flowInProgress.Dock = DockStyle.Fill;
            this.flowInProgress.AutoScroll = true;
            this.flowInProgress.FlowDirection = FlowDirection.TopDown;
            this.flowInProgress.WrapContents = false;
            this.flowInProgress.BackColor = Color.FromArgb(245, 245, 245);
            this.flowInProgress.Padding = new Padding(5);

            this.pnlInProgress.Controls.Add(this.flowInProgress);
            this.pnlInProgress.Controls.Add(this.lblInProgressTitle);

            // pnlDone
            this.pnlDone.Dock = DockStyle.Left;
            this.pnlDone.Width = 300;
            this.pnlDone.Padding = new Padding(5);
            this.pnlDone.BackColor = Color.White;

            this.lblDoneTitle.Dock = DockStyle.Top;
            this.lblDoneTitle.Height = 45;
            this.lblDoneTitle.Text = "✅ منجزة";
            this.lblDoneTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblDoneTitle.ForeColor = Color.White;
            this.lblDoneTitle.BackColor = Color.FromArgb(76, 175, 80);
            this.lblDoneTitle.TextAlign = ContentAlignment.MiddleCenter;

            this.flowDone.Dock = DockStyle.Fill;
            this.flowDone.AutoScroll = true;
            this.flowDone.FlowDirection = FlowDirection.TopDown;
            this.flowDone.WrapContents = false;
            this.flowDone.BackColor = Color.FromArgb(245, 245, 245);
            this.flowDone.Padding = new Padding(5);

            this.pnlDone.Controls.Add(this.flowDone);
            this.pnlDone.Controls.Add(this.lblDoneTitle);

            // ترتيب الأعمدة (RightToLeft - العكس)
            this.pnlBoard.Controls.Add(this.pnlDone);
            this.pnlBoard.Controls.Add(this.pnlInProgress);
            this.pnlBoard.Controls.Add(this.pnlNew);

            // ترتيب الإضافة
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);

            // النموذج
            this.ClientSize = new Size(1100, 700);
            this.MinimumSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "لوحة كانبان";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBoard.ResumeLayout(false);
            this.pnlNew.ResumeLayout(false);
            this.pnlInProgress.ResumeLayout(false);
            this.pnlDone.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}