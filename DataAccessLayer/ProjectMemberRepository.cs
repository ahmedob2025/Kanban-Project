using KanbanProjectManagementSystem.Common.Entities;
using System.Data;
using System.Data.SqlClient;

namespace KanbanProjectManagementSystem.DataAccessLayer
{
    /// <summary>
    /// مستودع بيانات أعضاء المشاريع.
    /// يتعامل مع جدول ProjectMembers.
    /// يغطي المتطلب الوظيفي FR-08 (إدارة أعضاء المشروع).
    /// </summary>
    public class ProjectMemberRepository
    {
        /// <summary>
        /// إضافة عضو جديد إلى مشروع.
        /// </summary>
        /// <param name="projectId">معرف المشروع</param>
        /// <param name="userId">معرف المستخدم</param>
        public void AddMember(int projectId, int userId)
        {
            string query = @"
                INSERT INTO ProjectMembers (ProjectID, UserID)
                VALUES (@ProjectID, @UserID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProjectID", projectId),
                new SqlParameter("@UserID", userId)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// إزالة عضو من مشروع.
        /// </summary>
        /// <param name="projectId">معرف المشروع</param>
        /// <param name="userId">معرف المستخدم</param>
        public void RemoveMember(int projectId, int userId)
        {
            string query = @"
                DELETE FROM ProjectMembers 
                WHERE ProjectID = @ProjectID AND UserID = @UserID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProjectID", projectId),
                new SqlParameter("@UserID", userId)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// جلب جميع أعضاء مشروع معين.
        /// </summary>
        /// <param name="projectId">معرف المشروع</param>
        /// <returns>قائمة من كائنات ProjectMember</returns>
        public List<ProjectMember> GetMembersByProject(int projectId)
        {
            string query = @"
                SELECT ProjectMemberID, ProjectID, UserID, JoinedDate
                FROM ProjectMembers
                WHERE ProjectID = @ProjectID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProjectID", projectId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            var members = new List<ProjectMember>();

            foreach (DataRow row in dt.Rows)
            {
                members.Add(new ProjectMember
                {
                    ProjectMemberID = Convert.ToInt32(row["ProjectMemberID"]),
                    ProjectID = Convert.ToInt32(row["ProjectID"]),
                    UserID = Convert.ToInt32(row["UserID"]),
                    JoinedDate = Convert.ToDateTime(row["JoinedDate"])
                });
            }

            return members;
        }

        /// <summary>
        /// جلب المستخدمين الأعضاء في مشروع معين (معلومات المستخدم كاملة).
        /// تستخدم لتعبئة قوائم الإسناد مثلاً.
        /// </summary>
        /// <param name="projectId">معرف المشروع</param>
        /// <returns>قائمة من كائنات User</returns>
        public List<User> GetUsersByProject(int projectId)
        {
            string query = @"
                SELECT u.UserID, u.Username, u.FullName, u.Email, u.PasswordHash, u.RoleID, u.IsActive, u.CreatedDate
                FROM Users u
                INNER JOIN ProjectMembers pm ON u.UserID = pm.UserID
                WHERE pm.ProjectID = @ProjectID AND u.IsActive = 1
                ORDER BY u.FullName";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProjectID", projectId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            var users = new List<User>();

            foreach (DataRow row in dt.Rows)
            {
                users.Add(new User
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString()!,
                    FullName = row["FullName"].ToString()!,
                    Email = row["Email"].ToString()!,
                    PasswordHash = row["PasswordHash"].ToString()!,
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                });
            }

            return users;
        }

        /// <summary>
        /// التحقق مما إذا كان المستخدم عضوًا في مشروع معين.
        /// تفيد في تطبيق قاعدة العمل BR-02 (لا إسناد لغير عضو).
        /// </summary>
        /// <param name="projectId">معرف المشروع</param>
        /// <param name="userId">معرف المستخدم</param>
        /// <returns>true إذا كان عضوًا، false إذا لم يكن</returns>
        public bool IsUserMemberOfProject(int projectId, int userId)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM ProjectMembers 
                WHERE ProjectID = @ProjectID AND UserID = @UserID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProjectID", projectId),
                new SqlParameter("@UserID", userId)
            };

            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }
    }
}