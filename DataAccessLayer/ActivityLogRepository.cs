using KanbanProjectManagementSystem.Common.Entities;
using System.Data;
using System.Data.SqlClient;

namespace KanbanProjectManagementSystem.DataAccessLayer
{
    /// <summary>
    /// مستودع بيانات سجل النشاطات.
    /// يتعامل مع جدول TaskHistory.
    /// </summary>
    public class ActivityLogRepository
    {
        /// <summary>
        /// إدراج سجل نشاط جديد [BR-09].
        /// </summary>
        public void Insert(TaskHistory history)
        {
            string query = @"INSERT INTO TaskHistory (TaskID, UserID, ActionType, Description)
                             VALUES (@TaskID, @UserID, @ActionType, @Description)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@TaskID", history.TaskID),
                new SqlParameter("@UserID", history.UserID),
                new SqlParameter("@ActionType", history.ActionType),
                new SqlParameter("@Description", history.Description)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// جلب سجل النشاطات لمهمة محددة.
        /// </summary>
        public List<TaskHistory> GetHistoryByTask(int taskId)
        {
            string query = "SELECT * FROM TaskHistory WHERE TaskID = @TaskID ORDER BY ActionDate DESC";
            var parameters = new[] { new SqlParameter("@TaskID", taskId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            var history = new List<TaskHistory>();
            foreach (DataRow row in dt.Rows)
            {
                history.Add(new TaskHistory
                {
                    HistoryID = Convert.ToInt32(row["HistoryID"]),
                    TaskID = Convert.ToInt32(row["TaskID"]),
                    UserID = Convert.ToInt32(row["UserID"]),
                    ActionType = row["ActionType"].ToString()!,
                    Description = row["Description"].ToString()!,
                    ActionDate = Convert.ToDateTime(row["ActionDate"])
                });
            }
            return history;
        }

        /// <summary>
        /// جلب سجل النشاطات لمشروع كامل (عبر المهام المرتبطة).
        /// </summary>
        public List<TaskHistory> GetHistoryByProject(int projectId)
        {
            string query = @"SELECT th.* FROM TaskHistory th
                             INNER JOIN Tasks t ON th.TaskID = t.TaskID
                             WHERE t.ProjectID = @ProjectID
                             ORDER BY th.ActionDate DESC";
            var parameters = new[] { new SqlParameter("@ProjectID", projectId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            var history = new List<TaskHistory>();
            foreach (DataRow row in dt.Rows)
            {
                history.Add(new TaskHistory
                {
                    HistoryID = Convert.ToInt32(row["HistoryID"]),
                    TaskID = Convert.ToInt32(row["TaskID"]),
                    UserID = Convert.ToInt32(row["UserID"]),
                    ActionType = row["ActionType"].ToString()!,
                    Description = row["Description"].ToString()!,
                    ActionDate = Convert.ToDateTime(row["ActionDate"])
                });
            }
            return history;
        }
    }
}