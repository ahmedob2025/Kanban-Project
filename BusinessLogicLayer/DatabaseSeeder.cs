using KanbanProjectManagementSystem.Common.Entities;
using KanbanProjectManagementSystem.DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// فئة مسؤولة عن تهيئة البيانات الأساسية عند أول تشغيل.
    /// تنشئ حساب Administrator افتراضي إذا لم يكن موجوداً.
    /// </summary>
    public static class DatabaseSeeder
    {
        // بيانات الحساب الافتراضي (يمكن تغييرها)
        private const string DefaultAdminUsername = "admin";
        private const string DefaultAdminPassword = "Admin@123";
        private const string DefaultAdminFullName = "مدير النظام";
        private const string DefaultAdminEmail = "admin@kanban.local";

        /// <summary>
        /// ينشئ حساب Administrator افتراضي إذا لم يكن موجوداً في قاعدة البيانات.
        /// يتم استدعاؤها عند بدء التطبيق.
        /// </summary>
        public static void SeedDefaultAdmin()
        {
            try
            {
                var userRepo = new UserRepository();

                // التحقق من وجود المستخدم مسبقاً
                var existing = userRepo.GetByUsername(DefaultAdminUsername);
                if (existing != null)
                    return;

                // إنشاء كائن المستخدم
                var admin = new User
                {
                    Username = DefaultAdminUsername,
                    FullName = DefaultAdminFullName,
                    Email = DefaultAdminEmail,
                    PasswordHash = AuthenticationService.HashPassword(DefaultAdminPassword),
                    RoleID = 1,      // Administrator
                    IsActive = true
                };

                userRepo.Insert(admin);
            }
            catch (Exception ex)
            {
                // لا نرمي استثناء حتى لا يتوقف التطبيق عن العمل
                System.Diagnostics.Debug.WriteLine($"خطأ أثناء إنشاء المستخدم الافتراضي: {ex.Message}");
            }
        }
    }
}