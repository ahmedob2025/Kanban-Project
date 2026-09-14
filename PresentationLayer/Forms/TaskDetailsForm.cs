

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class TaskDetailsForm : Form
    {
        private readonly TaskService _taskService = new();
        private readonly int _taskId;

        public TaskDetailsForm(int taskId)
        {
            InitializeComponent();
            _taskId = taskId;
            LoadTask();
        }

        private void LoadTask()
        {
            var task = _taskService.GetTaskById(_taskId);
            if (task == null)
            {
                MessageBox.Show("المهمة غير موجودة.");
                Close();
                return;
            }

            lblTitle.Text = $"العنوان: {task.Title}";
            lblDescription.Text = $"الوصف: {task.Description}";
            lblStatus.Text = $"الحالة: {task.Status}";
            lblPriority.Text = $"الأولوية: {task.Priority}";
            lblDueDate.Text = $"تاريخ الاستحقاق: {task.DueDate?.ToShortDateString() ?? "-"}";

            dgvSubTasks.DataSource = _taskService.GetSubTasks(_taskId);
        }

        private void btnAddSubTask_Click(object sender, EventArgs e)
        {
            var task = _taskService.GetTaskById(_taskId);
            if (task == null) return;

            using var frm = new AddEditTaskForm(task.ProjectID);
            if (frm.ShowDialog() == DialogResult.OK) LoadTask();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}