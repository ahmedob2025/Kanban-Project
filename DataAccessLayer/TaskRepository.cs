using KanbanProjectManagementSystem.Common.Entities;
using System.Data;
using System.Data.SqlClient;

namespace KanbanProjectManagementSystem.DataAccessLayer
{
    /// <summary>
    /// مستودع بيانات المهام.
    /// يتعامل مع جدول Tasks.
    /// </summary>
    public class TaskRepository
    {
        /// <summary>
        /// جلب مهمة بواسطة المعرف.
        /// </summary>
        public KanbanTask? GetById(int taskId)
        {
            string query = "SELECT * FROM Tasks WHERE TaskID = @TaskID";
            var parameters = new[] { new SqlParameter("@TaskID", taskId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0)
                return null;
            return MapTask(dt.Rows[0]);
        }

        /// <summary>
        /// جلب المهام المرتبطة بمشروع.
        /// </summary>
        public List<KanbanTask> GetTasksByProject(int projectId)
        {
            string query = "SELECT * FROM Tasks WHERE ProjectID = @ProjectID";
            var parameters = new[] { new SqlParameter("@ProjectID", projectId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            var tasks = new List<KanbanTask>();
            foreach (DataRow row in dt.Rows)
                tasks.Add(MapTask(row));
            return tasks;
        }

        /// <summary>
        /// جلب المهام الفرعية لمهمة رئيسية.
        /// </summary>
        public List<KanbanTask> GetSubTasks(int parentTaskId)
        {
            string query = "SELECT * FROM Tasks WHERE ParentTaskID = @ParentTaskID";
            var parameters = new[] { new SqlParameter("@ParentTaskID", parentTaskId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            var tasks = new List<KanbanTask>();
            foreach (DataRow row in dt.Rows)
                tasks.Add(MapTask(row));
            return tasks;
        }

        /// <summary>
        /// إدراج مهمة جديدة.
        /// </summary>
        public int Insert(KanbanTask task)
        {
            string query = @"INSERT INTO Tasks (Title, Description, ProjectID, ParentTaskID, AssignedTo, Priority, Status, DueDate, CreatedBy)
                             VALUES (@Title, @Description, @ProjectID, @ParentTaskID, @AssignedTo, @Priority, @Status, @DueDate, @CreatedBy);
                             SELECT SCOPE_IDENTITY();";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Title", task.Title),
                new SqlParameter("@Description", (object?)task.Description ?? DBNull.Value),
                new SqlParameter("@ProjectID", task.ProjectID),
                new SqlParameter("@ParentTaskID", (object?)task.ParentTaskID ?? DBNull.Value),
                new SqlParameter("@AssignedTo", (object?)task.AssignedTo ?? DBNull.Value),
                new SqlParameter("@Priority", task.Priority),
                new SqlParameter("@Status", task.Status),
                new SqlParameter("@DueDate", (object?)task.DueDate ?? DBNull.Value),
                new SqlParameter("@CreatedBy", task.CreatedBy)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }

        /// <summary>
        /// تحديث بيانات مهمة.
        /// </summary>
        public void Update(KanbanTask task)
        {
            string query = @"UPDATE Tasks SET
                                Title = @Title,
                                Description = @Description,
                                ParentTaskID = @ParentTaskID,
                                AssignedTo = @AssignedTo,
                                Priority = @Priority,
                                DueDate = @DueDate,
                                LastModifiedDate = GETDATE()
                             WHERE TaskID = @TaskID";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Title", task.Title),
                new SqlParameter("@Description", (object?)task.Description ?? DBNull.Value),
                new SqlParameter("@ParentTaskID", (object?)task.ParentTaskID ?? DBNull.Value),
                new SqlParameter("@AssignedTo", (object?)task.AssignedTo ?? DBNull.Value),
                new SqlParameter("@Priority", task.Priority),
                new SqlParameter("@DueDate", (object?)task.DueDate ?? DBNull.Value),
                new SqlParameter("@TaskID", task.TaskID)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// تحديث حالة المهمة فقط.
        /// </summary>
        public void UpdateStatus(int taskId, string newStatus)
        {
            string query = "UPDATE Tasks SET Status = @Status, LastModifiedDate = GETDATE() WHERE TaskID = @TaskID";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", newStatus),
                new SqlParameter("@TaskID", taskId)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// حذف مهمة.
        /// </summary>
        public void Delete(int taskId)
        {
            string query = "DELETE FROM Tasks WHERE TaskID = @TaskID";
            var parameters = new[] { new SqlParameter("@TaskID", taskId) };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// تحويل صف DataRow إلى كائن KanbanTask.
        /// </summary>
        private KanbanTask MapTask(DataRow row)
        {
            return new KanbanTask
            {
                TaskID = Convert.ToInt32(row["TaskID"]),
                Title = row["Title"].ToString()!,
                Description = row["Description"]?.ToString(),
                ProjectID = Convert.ToInt32(row["ProjectID"]),
                ParentTaskID = row["ParentTaskID"] == DBNull.Value ? null : Convert.ToInt32(row["ParentTaskID"]),
                AssignedTo = row["AssignedTo"] == DBNull.Value ? null : Convert.ToInt32(row["AssignedTo"]),
                Priority = Convert.ToInt32(row["Priority"]),
                Status = row["Status"].ToString()!,
                DueDate = row["DueDate"] == DBNull.Value ? null : Convert.ToDateTime(row["DueDate"]),
                CreatedBy = Convert.ToInt32(row["CreatedBy"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                LastModifiedDate = row["LastModifiedDate"] == DBNull.Value ? null : Convert.ToDateTime(row["LastModifiedDate"])
            };
        }
        /// <summary>
        /// جلب المهام المسندة لمستخدم معين.
        /// </summary>
        public List<KanbanTask> GetTasksByAssignedUser(int userId, int? projectId = null)
        {
            string query = @"SELECT * FROM Tasks WHERE AssignedTo = @UserID";
            if (projectId.HasValue && projectId.Value > 0)
                query += " AND ProjectID = @ProjectID";
            query += " ORDER BY Status, Priority, DueDate";

            var parameters = new List<SqlParameter> { new SqlParameter("@UserID", userId) };
            if (projectId.HasValue && projectId.Value > 0)
                parameters.Add(new SqlParameter("@ProjectID", projectId.Value));

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
            var tasks = new List<KanbanTask>();
            foreach (DataRow row in dt.Rows)
                tasks.Add(MapTask(row));
            return tasks;
        }
    }
}