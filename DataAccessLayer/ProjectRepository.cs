using KanbanProjectManagementSystem.Common.Entities;
using System.Data;
using System.Data.SqlClient;

namespace KanbanProjectManagementSystem.DataAccessLayer
{
    /// <summary>
    /// مستودع بيانات المشاريع.
    /// يتعامل مع جدول Projects.
    /// </summary>
    public class ProjectRepository
    {
        /// <summary>
        /// جلب مشروع بواسطة المعرف.
        /// </summary>
        public Project? GetById(int projectId)
        {
            string query = "SELECT * FROM Projects WHERE ProjectID = @ProjectID";
            var parameters = new[] { new SqlParameter("@ProjectID", projectId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0)
                return null;
            return MapProject(dt.Rows[0]);
        }

        /// <summary>
        /// جلب جميع المشاريع.
        /// </summary>
        public List<Project> GetAll()
        {
            string query = "SELECT * FROM Projects";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            var projects = new List<Project>();
            foreach (DataRow row in dt.Rows)
                projects.Add(MapProject(row));
            return projects;
        }

        /// <summary>
        /// جلب المشاريع المتاحة للمستخدم حسب دوره.
        /// Administrator وProjectLeader يرون الكل، TeamMember يرى مشاريعه فقط.
        /// </summary>
        public List<Project> GetProjectsForUser(int userId, int roleId)
        {
            string query;
            SqlParameter[] parameters;

            if (roleId == 1 || roleId == 2) // Administrator أو ProjectLeader
            {
                query = "SELECT * FROM Projects";
                parameters = Array.Empty<SqlParameter>();
            }
            else // TeamMember
            {
                query = @"SELECT p.* FROM Projects p
                          INNER JOIN ProjectMembers pm ON p.ProjectID = pm.ProjectID
                          WHERE pm.UserID = @UserID";
                parameters = new[] { new SqlParameter("@UserID", userId) };
            }

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            var projects = new List<Project>();
            foreach (DataRow row in dt.Rows)
                projects.Add(MapProject(row));
            return projects;
        }

        /// <summary>
        /// إدراج مشروع جديد.
        /// </summary>
        public int Insert(Project project)
        {
            string query = @"INSERT INTO Projects (ProjectName, Description, StartDate, ExpectedEndDate, Status, CreatedBy)
                             VALUES (@ProjectName, @Description, @StartDate, @ExpectedEndDate, @Status, @CreatedBy);
                             SELECT SCOPE_IDENTITY();";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProjectName", project.ProjectName),
                new SqlParameter("@Description", (object?)project.Description ?? DBNull.Value),
                new SqlParameter("@StartDate", project.StartDate),
                new SqlParameter("@ExpectedEndDate", (object?)project.ExpectedEndDate ?? DBNull.Value),
                new SqlParameter("@Status", project.Status),
                new SqlParameter("@CreatedBy", project.CreatedBy)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }

        /// <summary>
        /// تحديث بيانات مشروع.
        /// </summary>
        public void Update(Project project)
        {
            string query = @"UPDATE Projects SET
                                ProjectName = @ProjectName,
                                Description = @Description,
                                StartDate = @StartDate,
                                ExpectedEndDate = @ExpectedEndDate,
                                Status = @Status
                             WHERE ProjectID = @ProjectID";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProjectName", project.ProjectName),
                new SqlParameter("@Description", (object?)project.Description ?? DBNull.Value),
                new SqlParameter("@StartDate", project.StartDate),
                new SqlParameter("@ExpectedEndDate", (object?)project.ExpectedEndDate ?? DBNull.Value),
                new SqlParameter("@Status", project.Status),
                new SqlParameter("@ProjectID", project.ProjectID)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// التحقق من أن المستخدم عضو في المشروع [BR-02].
        /// </summary>
        public bool IsUserMemberOfProject(int projectId, int userId)
        {
            string query = "SELECT COUNT(*) FROM ProjectMembers WHERE ProjectID = @ProjectID AND UserID = @UserID";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProjectID", projectId),
                new SqlParameter("@UserID", userId)
            };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        /// <summary>
        /// تحويل صف DataRow إلى كائن Project.
        /// </summary>
        private Project MapProject(DataRow row)
        {
            return new Project
            {
                ProjectID = Convert.ToInt32(row["ProjectID"]),
                ProjectName = row["ProjectName"].ToString()!,
                Description = row["Description"]?.ToString(),
                StartDate = Convert.ToDateTime(row["StartDate"]),
                ExpectedEndDate = row["ExpectedEndDate"] == DBNull.Value ? null : Convert.ToDateTime(row["ExpectedEndDate"]),
                Status = row["Status"].ToString()!,
                CreatedBy = Convert.ToInt32(row["CreatedBy"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"])
            };
        }
    }
}