

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class ProjectReportsForm : Form
    {
        private readonly ReportService _reportService = new();
        private readonly int _projectId;

        public ProjectReportsForm(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            LoadReports();
        }

        private void LoadReports()
        {
            var summary = _reportService.GetProjectSummary(_projectId);
            lblTotal.Text = $"إجمالي المهام: {summary.total}";
            lblNew.Text = $"جديدة: {summary.newCount}";
            lblInProgress.Text = $"قيد التنفيذ: {summary.inProgress}";
            lblDone.Text = $"منجزة: {summary.done}";

            double progress = _reportService.GetProjectProgress(_projectId);
            progressBar.Value = Math.Min(100, (int)Math.Round(progress));
            lblProgress.Text = $"نسبة الإنجاز: {progress:F2}%";

            var performance = _reportService.GetTeamPerformance(_projectId);
            dgvPerformance.DataSource = performance.Select(p => new
            {
                العضو = p.user.FullName,
                المهام_المنجزة = p.completedTasks
            }).ToList();
        }
    }
}