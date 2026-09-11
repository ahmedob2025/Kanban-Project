using KanbanProjectManagementSystem.Common.Entities;
using System.Data;
using System.Data.SqlClient;

namespace KanbanProjectManagementSystem.DataAccessLayer
{
    /// <summary>
    /// مستودع بيانات التقارير.
    /// يوفر استعلامات مجمعة للإحصائيات.
    /// </summary>
    public class ReportRepository
    {
        /// <summary>
        /// الحصول على ملخص المشروع (عدد المهام حسب الحالة).
        /// </summary>
        public (int total, int newCount, int inProgress, int done) GetProjectSummary(int projectId)
        {
            string query = @"
                SELECT
                    COUNT(*) AS Total,
                    SUM(CASE WHEN Status = 'New' THEN 1 ELSE 0 END) AS NewCount,
                    SUM(CASE WHEN Status = 'InProgress' THEN 1 ELSE 0 END) AS InProgressCount,
                    SUM(CASE WHEN Status = 'Done' THEN 1 ELSE 0 END) AS DoneCount
                FROM Tasks
                WHERE ProjectID = @ProjectID";
            var parameters = new[] { new SqlParameter("@ProjectID", projectId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0)
                return (0, 0, 0, 0);
            DataRow row = dt.Rows[0];
            int total = Convert.ToInt32(row["Total"]);
            int newCount = row["NewCount"] == DBNull.Value ? 0 : Convert.ToInt32(row["NewCount"]);
            int inProgress = row["InProgressCount"] == DBNull.Value ? 0 : Convert.ToInt32(row["InProgressCount"]);
            int done = row["DoneCount"] == DBNull.Value ? 0 : Convert.ToInt32(row["DoneCount"]);
            return (total, newCount, inProgress, done);
        }

        /// <summary>
        /// حساب أداء أعضاء الفريق (عدد المهام المنجزة لكل عضو).
        /// </summary>
        public List<(User user, int completedTasks)> GetTeamPerformance(int projectId)
        {
            string query = @"
                SELECT u.*, ISNULL(SUM(CASE WHEN t.Status = 'Done' THEN 1 ELSE 0 END),0) AS CompletedTasks
                FROM Users u
                INNER JOIN ProjectMembers pm ON u.UserID = pm.UserID
                LEFT JOIN Tasks t ON pm.UserID = t.AssignedTo AND t.ProjectID = @ProjectID
                WHERE pm.ProjectID = @ProjectID
                GROUP BY u.UserID, u.Username, u.FullName, u.Email, u.PasswordHash, u.RoleID, u.IsActive, u.CreatedDate";
            var parameters = new[] { new SqlParameter("@ProjectID", projectId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            var result = new List<(User, int)>();
            foreach (DataRow row in dt.Rows)
            {
                var user = new User
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString()!,
                    FullName = row["FullName"].ToString()!,
                    Email = row["Email"].ToString()!,
                    PasswordHash = row["PasswordHash"].ToString()!,
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                };
                int completed = Convert.ToInt32(row["CompletedTasks"]);
                result.Add((user, completed));
            }
            return result;
        }
    }
}