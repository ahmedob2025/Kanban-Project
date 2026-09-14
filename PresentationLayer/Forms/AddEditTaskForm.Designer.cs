using System;
using System.Drawing;
using System.Windows.Forms;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    partial class AddEditTaskForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private ComboBox cmbAssignedTo;
        private ComboBox cmbPriority;
        private ComboBox cmbStatus;
        private DateTimePicker dtpDueDate;
        private Button btnSave;
        private Button btnCancel;
        private Label lblTitle;
        private Label lblDesc;
        private Label lblAssigned;
        private Label lblPriority;
        private Label lblStatus;
        private Label lblDue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblDesc = new Label();
            this.lblAssigned = new Label();
            this.lblPriority = new Label();
            this.lblStatus = new Label();
            this.lblDue = new Label();
            this.txtTitle = new TextBox();
            this.txtDescription = new TextBox();
            this.cmbAssignedTo = new ComboBox();
            this.cmbPriority = new ComboBox();
            this.cmbStatus = new ComboBox();
            this.dtpDueDate = new DateTimePicker();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // ═══════════════ Labels ═══════════════
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitle.Location = new Point(30, 30);
            this.lblTitle.Text = "عنوان المهمة:";

            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDesc.Location = new Point(30, 75);
            this.lblDesc.Text = "الوصف:";

            this.lblAssigned.AutoSize = true;
            this.lblAssigned.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblAssigned.Location = new Point(30, 150);
            this.lblAssigned.Text = "مسند إلى:";

            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPriority.Location = new Point(30, 195);
            this.lblPriority.Text = "الأولوية:";

            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStatus.Location = new Point(30, 240);
            this.lblStatus.Text = "الحالة:";

            this.lblDue.AutoSize = true;
            this.lblDue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDue.Location = new Point(30, 285);
            this.lblDue.Text = "تاريخ الاستحقاق:";

            // ═══════════════ TextBoxes ═══════════════
            this.txtTitle.Font = new Font("Segoe UI", 10F);
            this.txtTitle.Location = new Point(160, 27);
            this.txtTitle.Size = new Size(280, 27);
            this.txtTitle.BorderStyle = BorderStyle.FixedSingle;

            this.txtDescription.Font = new Font("Segoe UI", 10F);
            this.txtDescription.Location = new Point(160, 72);
            this.txtDescription.Size = new Size(280, 60);
            this.txtDescription.Multiline = true;
            this.txtDescription.BorderStyle = BorderStyle.FixedSingle;

            // ═══════════════ ComboBoxes ═══════════════
            this.cmbAssignedTo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAssignedTo.Font = new Font("Segoe UI", 10F);
            this.cmbAssignedTo.Location = new Point(160, 147);
            this.cmbAssignedTo.Size = new Size(280, 28);

            this.cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPriority.Font = new Font("Segoe UI", 10F);
            this.cmbPriority.Items.AddRange(new object[] { "High", "Medium", "Low" });
            this.cmbPriority.Location = new Point(160, 192);
            this.cmbPriority.Size = new Size(280, 28);
            this.cmbPriority.SelectedIndex = 1; // افتراضي: Medium

            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new Font("Segoe UI", 10F);
            this.cmbStatus.Items.AddRange(new object[] { "New", "InProgress", "Done" });
            this.cmbStatus.Location = new Point(160, 237);
            this.cmbStatus.Size = new Size(280, 28);
            this.cmbStatus.SelectedIndex = 0; // افتراضي: New

            // ═══════════════ DateTimePicker ═══════════════
            this.dtpDueDate.Font = new Font("Segoe UI", 10F);
            this.dtpDueDate.Location = new Point(160, 282);
            this.dtpDueDate.Size = new Size(280, 27);
            this.dtpDueDate.ShowCheckBox = true;
            this.dtpDueDate.Checked = false;

            // ═══════════════ Buttons ═══════════════
            this.btnSave.BackColor = Color.FromArgb(76, 175, 80);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnSave.Location = new Point(160, 330);
            this.btnSave.Size = new Size(130, 42);
            this.btnSave.Text = "💾 حفظ";
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            this.btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnCancel.Location = new Point(310, 330);
            this.btnCancel.Size = new Size(130, 42);
            this.btnCancel.Text = "❌ إلغاء";
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // ═══════════════ Form ═══════════════
            this.ClientSize = new Size(480, 410);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAssigned);
            this.Controls.Add(this.cmbAssignedTo);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "تفاصيل المهمة";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}