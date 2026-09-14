
using KanbanProjectManagementSystem.Common.Entities;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly ProjectService _projectService = new();
        private readonly TaskService _taskService = new();

        public DashboardForm()
        {
            InitializeComponent();
            ApplyRolePermissions();
            LoadDashboard();
        }

        /// <summary>
        /// تطبيق الصلاحيات حسب الدور (BR-10).
        /// </summary>
        private void ApplyRolePermissions()
        {
            var user = SessionManager.CurrentUser;
            if (user == null) return;

            bool isAdmin = user.RoleID == 1;
            bool isLeader = user.RoleID == 2;
            bool isMember = user.RoleID == 3;

            btnManageUsers.Visible = isAdmin;
            btnOpenProjects.Visible = isAdmin || isLeader;
            btnChangeTaskStatus.Visible = isMember;

            tabMyTasks.Text = isMember ? "📌  مهامي" : "📌  المهام المسندة إليّ";

            // لعضو الفريق: افتح تبويب "مهامي" تلقائياً
            if (isMember)
                tabMain.SelectedTab = tabMyTasks;
        }

        /// <summary>
        /// تحميل لوحة المعلومات.
        /// </summary>
        private void LoadDashboard()
        {
            try
            {
                var user = SessionManager.CurrentUser;
                if (user == null) return;

                string roleName = user.RoleID switch
                {
                    1 => "مدير النظام",
                    2 => "قائد مشروع",
                    3 => "عضو فريق",
                    _ => "مستخدم"
                };
                lblWelcome.Text = $"مرحباً، {user.FullName} ({roleName})";

                // المشاريع
                var projects = _projectService.GetProjectsForUser(user.UserID, user.RoleID)
                               ?? new List<Project>();
                dgvProjects.DataSource = projects;

                // المهام المسندة
                var myTasks = _taskService.GetTasksByAssignedUser(user.UserID)
                              ?? new List<KanbanTask>();
                dgvMyTasks.DataSource = myTasks;

                int pending = myTasks.Count(t => t.Status != "Done");
                lblSummary.Text = $"📋 المشاريع: {projects.Count}   |   📌 مهامي: {myTasks.Count}   |   ⏳ مهام معلقة: {pending}";

                CustomizeProjectColumns();
                CustomizeTaskColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء تحميل البيانات:\n{ex.Message}\n\n{ex.StackTrace}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeProjectColumns()
        {
            if (dgvProjects.Columns.Count == 0) return;

            void Hide(string col)
            {
                if (dgvProjects.Columns.Contains(col)) dgvProjects.Columns[col].Visible = false;
            }
            void SetHeader(string col, string header)
            {
                if (dgvProjects.Columns.Contains(col)) dgvProjects.Columns[col].HeaderText = header;
            }

            Hide("Description"); Hide("CreatedBy"); Hide("ProjectID"); Hide("CreatedDate");

            SetHeader("ProjectName", "اسم المشروع");
            SetHeader("Status", "الحالة");
            SetHeader("StartDate", "تاريخ البداية");
            SetHeader("ExpectedEndDate", "تاريخ النهاية المتوقع");
        }

        private void CustomizeTaskColumns()
        {
            if (dgvMyTasks.Columns.Count == 0) return;

            void Hide(string col)
            {
                if (dgvMyTasks.Columns.Contains(col)) dgvMyTasks.Columns[col].Visible = false;
            }
            void SetHeader(string col, string header)
            {
                if (dgvMyTasks.Columns.Contains(col)) dgvMyTasks.Columns[col].HeaderText = header;
            }

            Hide("Description"); Hide("CreatedBy"); Hide("ProjectID"); Hide("ParentTaskID");
            Hide("AssignedTo"); Hide("CreatedDate"); Hide("LastModifiedDate");

            SetHeader("TaskID", "الرقم");
            SetHeader("Title", "عنوان المهمة");
            SetHeader("Priority", "الأولوية");
            SetHeader("Status", "الحالة");
            SetHeader("DueDate", "تاريخ الاستحقاق");

            // تحويل الأولوية إلى نص عربي
            if (dgvMyTasks.Columns.Contains("Priority"))
            {
                dgvMyTasks.CellFormatting -= DgvMyTasks_CellFormatting;
                dgvMyTasks.CellFormatting += DgvMyTasks_CellFormatting;
            }
        }

        private void DgvMyTasks_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            var col = dgvMyTasks.Columns[e.ColumnIndex].Name;

            if (col == "Priority" && e.Value != null)
            {
                e.Value = e.Value.ToString() switch
                {
                    "1" => "🔴 عالية",
                    "2" => "🟡 متوسطة",
                    "3" => "🟢 منخفضة",
                    _ => e.Value
                };
            }
            else if (col == "Status" && e.Value != null)
            {
                e.Value = e.Value.ToString() switch
                {
                    "New" => "🆕 جديدة",
                    "InProgress" => "⚙️ قيد التنفيذ",
                    "Done" => "✅ منجزة",
                    _ => e.Value
                };
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadDashboard();

        private void btnOpenProjects_Click(object sender, EventArgs e)
        {
            new ProjectsForm().Show();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            new UsersManagementForm().Show();
        }

        /// <summary>
        /// تغيير حالة المهمة المحددة في تبويب "مهامي".
        /// </summary>
        private void btnChangeTaskStatus_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab != tabMyTasks)
                tabMain.SelectedTab = tabMyTasks;

            if (dgvMyTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مهمة من الجدول أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int taskId = Convert.ToInt32(dgvMyTasks.SelectedRows[0].Cells["TaskID"].Value);
            string currentStatus = dgvMyTasks.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "New";

            string nextStatus = currentStatus switch
            {
                "New" => "InProgress",
                "InProgress" => "Done",
                _ => currentStatus
            };

            if (nextStatus == currentStatus)
            {
                MessageBox.Show("المهمة مكتملة بالفعل.", "معلومة",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _taskService.ChangeStatus(taskId, nextStatus, SessionManager.CurrentUser!.UserID);
                MessageBox.Show($"تم تغيير الحالة إلى: {nextStatus}",
                    "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}\n\n{ex.StackTrace}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.CurrentUser = null;
            Hide();
            new LoginForm().Show();
        }
    }
}