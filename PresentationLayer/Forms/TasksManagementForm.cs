

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class TasksManagementForm : Form
    {
        private readonly TaskService _taskService = new();
        private readonly int _projectId;

        public TasksManagementForm(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            LoadTasks();
        }

        private void LoadTasks()
        {
            dgvTasks.DataSource = _taskService.GetTasksByProject(_projectId);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            using var frm = new AddEditTaskForm(_projectId);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadTasks();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مهمة أولاً.");
                return;
            }

            int taskId = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["TaskID"].Value);
            using var frm = new AddEditTaskForm(_projectId, taskId);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadTasks();
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مهمة أولاً.");
                return;
            }

            int taskId = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["TaskID"].Value);

            if (MessageBox.Show("هل تريد حذف المهمة؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _taskService.DeleteTask(taskId, SessionManager.CurrentUser!.UserID);
                    LoadTasks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ: {ex.Message}");
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مهمة أولاً.");
                return;
            }

            int taskId = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["TaskID"].Value);
            new TaskDetailsForm(taskId).Show();
        }
    }
}