
using KanbanProjectManagementSystem.Common.Entities;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class AddEditTaskForm : Form
    {
        private readonly TaskService _taskService = new();
        private readonly ProjectService _projectService = new();
        private readonly int _projectId;
        private KanbanTask? _task;

        public AddEditTaskForm(int projectId, int? taskId = null)
        {
            try
            {
                InitializeComponent();
                _projectId = projectId;

                if (taskId.HasValue)
                {
                    _task = _taskService.GetTaskById(taskId.Value);
                    if (_task == null)
                    {
                        MessageBox.Show("لم يتم العثور على المهمة المطلوبة.", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.Cancel;
                        this.Load += (s, e) => Close();
                        return;
                    }
                    this.Text = "تعديل مهمة";
                }
                else
                {
                    _task = new KanbanTask { ProjectID = projectId };
                    this.Text = "إضافة مهمة جديدة";
                }

                LoadProjectUsers();

                if (taskId.HasValue)
                    LoadTaskData();
            }
            catch (Exception ex)
            {
                ShowDetailedError(ex, "خطأ أثناء تحميل النموذج");
            }
        }

        /// <summary>
        /// تحميل أعضاء المشروع في ComboBox بأمان تام.
        /// </summary>
        private void LoadProjectUsers()
        {
            try
            {
                // حماية: إن كان ComboBox غير مهيأ، لا نكمل
                if (cmbAssignedTo == null)
                {
                    System.Diagnostics.Debug.WriteLine("cmbAssignedTo is null!");
                    return;
                }

                var users = _projectService.GetProjectUsers(_projectId)
                            ?? new List<User>();

                cmbAssignedTo.DataSource = null;
                cmbAssignedTo.Items.Clear();

                if (users.Count == 0)
                {
                    cmbAssignedTo.Items.Add("(لا يوجد أعضاء في المشروع)");
                    cmbAssignedTo.SelectedIndex = 0;
                    cmbAssignedTo.Enabled = false;
                }
                else
                {
                    cmbAssignedTo.DataSource = users;
                    cmbAssignedTo.DisplayMember = "FullName";
                    cmbAssignedTo.ValueMember = "UserID";
                    cmbAssignedTo.SelectedIndex = -1;
                    cmbAssignedTo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ShowDetailedError(ex, "خطأ أثناء تحميل أعضاء المشروع");
            }
        }

        /// <summary>
        /// تعبئة الحقول في وضع التعديل.
        /// </summary>
        private void LoadTaskData()
        {
            if (_task == null) return;

            txtTitle.Text = _task.Title ?? "";
            txtDescription.Text = _task.Description ?? "";

            if (_task.AssignedTo.HasValue && cmbAssignedTo.Enabled)
            {
                try { cmbAssignedTo.SelectedValue = _task.AssignedTo.Value; }
                catch { /* تجاهل */ }
            }

            cmbPriority.SelectedItem = _task.Priority switch
            {
                1 => "High",
                2 => "Medium",
                _ => "Low"
            };

            cmbStatus.SelectedItem = _task.Status ?? "New";

            if (_task.DueDate.HasValue)
            {
                dtpDueDate.Value = _task.DueDate.Value;
                dtpDueDate.Checked = true;
            }
            else
            {
                dtpDueDate.Checked = false;
            }
        }

        /// <summary>
        /// حفظ المهمة.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionManager.CurrentUser == null)
                {
                    MessageBox.Show("انتهت الجلسة. سجّل الدخول مجدداً.",
                        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("عنوان المهمة مطلوب.", "تنبيه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTitle.Focus();
                    return;
                }

                if (_task == null) _task = new KanbanTask();

                _task.Title = txtTitle.Text.Trim();
                _task.Description = string.IsNullOrWhiteSpace(txtDescription.Text)
                    ? null : txtDescription.Text.Trim();
                _task.ProjectID = _projectId;

                // الإسناد
                int? assignedUserId = null;
                if (cmbAssignedTo.Enabled && cmbAssignedTo.SelectedItem is User u)
                    assignedUserId = u.UserID;
                _task.AssignedTo = assignedUserId;

                // الأولوية
                string priorityText = cmbPriority.SelectedItem?.ToString() ?? "Medium";
                _task.Priority = priorityText switch
                {
                    "High" => 1,
                    "Medium" => 2,
                    "Low" => 3,
                    _ => 2
                };

                // الحالة
                _task.Status = cmbStatus.SelectedItem?.ToString() ?? "New";

                // التاريخ
                _task.DueDate = dtpDueDate.Checked ? dtpDueDate.Value : null;

                // بيانات الإنشاء
                _task.CreatedBy = SessionManager.CurrentUser.UserID;
                if (_task.TaskID == 0)
                    _task.CreatedDate = DateTime.Now;

                // الحفظ
                if (_task.TaskID == 0)
                {
                    int newId = _taskService.CreateTask(_task);
                    MessageBox.Show($"تم إنشاء المهمة بنجاح (رقم: {newId}).",
                        "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _taskService.UpdateTask(_task, SessionManager.CurrentUser.UserID);
                    MessageBox.Show("تم تحديث المهمة بنجاح.",
                        "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ShowDetailedError(ex, "خطأ أثناء حفظ المهمة");
            }
        }

        /// <summary>
        /// عرض خطأ تفصيلي.
        /// </summary>
        private void ShowDetailedError(Exception ex, string title)
        {
            string msg = $"الرسالة: {ex.Message}";
            if (ex.InnerException != null)
                msg += $"\n\nالتفاصيل: {ex.InnerException.Message}";
            msg += $"\n\nالنوع: {ex.GetType().Name}";
            msg += $"\n\nالموقع:\n{ex.StackTrace}";
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}