using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KanbanProjectManagementSystem.DataAccessLayer
{
    /// <summary>
    /// فئة مساعدة للاتصال بقاعدة البيانات وتنفيذ الأوامر.
    /// تتوافق مع NFR-05 (Transaction Safety) وNFR-06 (Performance).
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// قراءة سلسلة الاتصال من ملف الإعدادات.
        /// </summary>
        private static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["KanbanDB"].ConnectionString;

        /// <summary>
        /// إنشاء اتصال SQL مفتوح.
        /// </summary>
        public static SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// تنفيذ استعلام SELECT وإرجاع DataTable.
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[]? parameters = null)
        {
            using var connection = GetOpenConnection();
            using var command = new SqlCommand(query, connection);
            if (parameters != null)
                command.Parameters.AddRange(parameters);

            using var adapter = new SqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        /// <summary>
        /// تنفيذ أمر INSERT/UPDATE/DELETE وإرجاع عدد الصفوف المتأثرة.
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[]? parameters = null)
        {
            using var connection = GetOpenConnection();
            using var command = new SqlCommand(query, connection);
            if (parameters != null)
                command.Parameters.AddRange(parameters);
            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// تنفيذ استعلام Scalar (مثل SELECT SCOPE_IDENTITY()).
        /// </summary>
        public static object ExecuteScalar(string query, SqlParameter[]? parameters = null)
        {
            using var connection = GetOpenConnection();
            using var command = new SqlCommand(query, connection);
            if (parameters != null)
                command.Parameters.AddRange(parameters);
            return command.ExecuteScalar()!;
        }

        /// <summary>
        /// تنفيذ عدة أوامر داخل معاملة واحدة لضمان الاتساق (NFR-05).
        /// </summary>
        public static void ExecuteInTransaction(params SqlCommand[] commands)
        {
            using var connection = GetOpenConnection();
            using var transaction = connection.BeginTransaction();
            try
            {
                foreach (var command in commands)
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}