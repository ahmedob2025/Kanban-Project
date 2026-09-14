namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class ActivityLogForm : Form
    {
        private readonly ActivityLogRepository _historyRepo = new();
        private readonly int? _taskId;
        private readonly int? _projectId;

        public ActivityLogForm(int? taskId = null, int? projectId = null)
        {
            InitializeComponent();
            _taskId = taskId;
            _projectId = projectId;
            LoadHistory();
        }

        private void LoadHistory()
        {
            List<TaskHistory> history = new();

            if (_taskId.HasValue)
                history = _historyRepo.GetHistoryByTask(_taskId.Value);
            else if (_projectId.HasValue)
                history = _historyRepo.GetHistoryByProject(_projectId.Value);

            dgvHistory.DataSource = history;
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadHistory();

        // Fixed: Implemented the Close button properly
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}