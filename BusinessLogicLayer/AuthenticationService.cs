using KanbanProjectManagementSystem.Common.Entities;
using KanbanProjectManagementSystem.DataAccessLayer;
using System.Security.Cryptography;

namespace BusinessLogicLayer
{
    /// <summary>
    /// خدمة المصادقة وتسجيل الدخول.
    /// تتوافق مع FR-01.
    /// </summary>
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;

        public AuthenticationService()
        {
            _userRepository = new UserRepository();
        }

        /// <summary>
        /// التحقق من بيانات الدخول.
        /// </summary>
        public User? Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = _userRepository.GetByUsername(username);
            if (user == null || !user.IsActive)
                return null;

            // التحقق من الهاش باستخدام PBKDF2
            if (!VerifyPassword(password, user.PasswordHash))
                return null;

            return user;
        }

        /// <summary>
        /// توليد هاش لكلمة المرور.
        /// </summary>
        public static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = GenerateHash(password, salt, 10000);
            return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        /// <summary>
        /// التحقق من كلمة المرور.
        /// </summary>
        private static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            if (parts.Length != 2)
                return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] expectedHash = Convert.FromBase64String(parts[1]);
            byte[] actualHash = GenerateHash(password, salt, 10000);
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }

        private static byte[] GenerateHash(string password, byte[] salt, int iterations)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(32);
        }
    }
}