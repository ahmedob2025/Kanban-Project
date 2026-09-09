using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DatabaseHelper
    {
        // هذه الدالة معرفة مباشرة داخل الكلاس (وليس داخل دالة أخرى)
        public static string TestConnection()
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["KanbanDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    return "✅ تم الاتصال بقاعدة البيانات بنجاح!";
                }
            }
            catch (Exception ex)
            {
                return "❌ فشل الاتصال: " + ex.Message;
            }
        }

        // ... يمكنك إضافة دوال أخرى هنا لاحقاً
    }
}