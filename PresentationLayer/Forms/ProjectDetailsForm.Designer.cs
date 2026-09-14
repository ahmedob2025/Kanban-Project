using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class ProjectDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtProjectName;
        private TextBox txtDescription;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;
        private Label lblName;
        private Label lblDesc;
        private Label lblStart;
        private Label lblEnd;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new Label();
            this.lblDesc = new Label();
            this.lblStart = new Label();
            this.lblEnd = new Label();
            this.lblStatus = new Label();
            this.txtProjectName = new TextBox();
            this.txtDescription = new TextBox();
            this.dtpStartDate = new DateTimePicker();
            this.dtpEndDate = new DateTimePicker();
            this.cmbStatus = new ComboBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(30, 40);
            this.lblName.Text = "اسم المشروع:";

            // txtProjectName
            this.txtProjectName.Location = new Point(150, 37);
            this.txtProjectName.Size = new Size(250, 27);

            // lblDesc
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new Point(30, 90);
            this.lblDesc.Text = "الوصف:";

            // txtDescription
            this.txtDescription.Location = new Point(150, 87);
            this.txtDescription.Size = new Size(250, 60);
            this.txtDescription.Multiline = true;

            // lblStart
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new Point(30, 170);
            this.lblStart.Text = "تاريخ البداية:";

            // dtpStartDate
            this.dtpStartDate.Location = new Point(150, 167);
            this.dtpStartDate.Size = new Size(250, 27);

            // lblEnd
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new Point(30, 220);
            this.lblEnd.Text = "تاريخ النهاية المتوقع:";

            // dtpEndDate
            this.dtpEndDate.Location = new Point(150, 217);
            this.dtpEndDate.Size = new Size(250, 27);
            this.dtpEndDate.ShowCheckBox = true;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(30, 270);
            this.lblStatus.Text = "الحالة:";

            // cmbStatus
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "New", "InProgress", "Completed", "OnHold" });
            this.cmbStatus.Location = new Point(150, 267);
            this.cmbStatus.Size = new Size(250, 28);

            // btnSave
            this.btnSave.Location = new Point(150, 330);
            this.btnSave.Size = new Size(100, 35);
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new Point(300, 330);
            this.btnCancel.Size = new Size(100, 35);
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // ProjectDetailsForm
            this.ClientSize = new Size(450, 400);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Text = "تفاصيل المشروع";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}