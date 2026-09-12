using KanbanProjectManagementSystem.DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// خدمة التقارير.
    /// تتوافق مع FR-24, FR-25, FR-26.
    /// </summary>
    public class ReportService
    {
        private readonly ReportRepository _reportRepository;

        public ReportService()
        {
            _reportRepository = new ReportRepository();
        }

        public (int total, int newCount, int inProgress, int done) GetProjectSummary(int projectId)
        {
            return _reportRepository.GetProjectSummary(projectId);
        }

        public double GetProjectProgress(int projectId)
        {
            var summary = _reportRepository.GetProjectSummary(projectId);
            if (summary.total == 0)
                return 0;
            return (double)summary.done / summary.total * 100;
        }

        public List<(Common.Entities.User user, int completedTasks)> GetTeamPerformance(int projectId)
        {
            return _reportRepository.GetTeamPerformance(projectId);
        }
    }
}