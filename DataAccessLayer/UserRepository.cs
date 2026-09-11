using KanbanProjectManagementSystem.Common.Entities;
using System.Data;
using System.Data.SqlClient;
namespace KanbanProjectManagementSystem.DataAccessLayer
{
    /// <summary>
    /// مستودع بيانات المستخدمين.
    /// يتعامل مع جدول Users.
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// جلب مستخدم بواسطة اسم المستخدم.
        /// </summary>
        public User? GetByUsername(string username)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username";
            var parameters = new[] { new SqlParameter("@Username", username) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0)
                return null;
            return MapUser(dt.Rows[0]);
        }

        /// <summary>
        /// جلب مستخدم بواسطة المعرف.
        /// </summary>
        public User? GetById(int userId)
        {
            string query = "SELECT * FROM Users WHERE UserID = @UserID";
            var parameters = new[] { new SqlParameter("@UserID", userId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 0)
                return null;
            return MapUser(dt.Rows[0]);
        }

        /// <summary>
        /// جلب جميع المستخدمين.
        /// </summary>
        public List<User> GetAll()
        {
            string query = "SELECT * FROM Users";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            var users = new List<User>();
            foreach (DataRow row in dt.Rows)
                users.Add(MapUser(row));
            return users;
        }

        /// <summary>
        /// إدراج مستخدم جديد.
        /// </summary>
        /// <returns>المعرف الجديد</returns>
        public int Insert(User user)
        {
            string query = @"INSERT INTO Users (Username, FullName, Email, PasswordHash, RoleID, IsActive)
                             VALUES (@Username, @FullName, @Email, @PasswordHash, @RoleID, @IsActive);
                             SELECT SCOPE_IDENTITY();";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@PasswordHash", user.PasswordHash),
                new SqlParameter("@RoleID", user.RoleID),
                new SqlParameter("@IsActive", user.IsActive)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }

        /// <summary>
        /// تحديث بيانات مستخدم.
        /// </summary>
        public void Update(User user)
        {
            string query = @"UPDATE Users SET
                                FullName = @FullName,
                                Email = @Email,
                                RoleID = @RoleID,
                                IsActive = @IsActive
                             WHERE UserID = @UserID";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@RoleID", user.RoleID),
                new SqlParameter("@IsActive", user.IsActive),
                new SqlParameter("@UserID", user.UserID)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// تعطيل مستخدم (حذف منطقي) [FR-04].
        /// </summary>
        public void Deactivate(int userId)
        {
            string query = "UPDATE Users SET IsActive = 0 WHERE UserID = @UserID";
            var parameters = new[] { new SqlParameter("@UserID", userId) };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// تحويل صف DataRow إلى كائن User.
        /// </summary>
        private User MapUser(DataRow row)
        {
            return new User
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
        }
    }
}