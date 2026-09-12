using KanbanProjectManagementSystem.Common.Entities;
using KanbanProjectManagementSystem.DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// خدمة إدارة المستخدمين.
    /// تتوافق مع FR-02, FR-03, FR-04.
    /// </summary>
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        /// <summary>
        /// إنشاء مستخدم جديد.
        /// </summary>
        public int CreateUser(User user, string plainPassword)
        {
            var existing = _userRepository.GetByUsername(user.Username);
            if (existing != null)
                throw new Exception("اسم المستخدم مستخدم مسبقًا.");

            user.PasswordHash = AuthenticationService.HashPassword(plainPassword);
            return _userRepository.Insert(user);
        }

        /// <summary>
        /// تعديل بيانات مستخدم.
        /// </summary>
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        /// <summary>
        /// تعطيل مستخدم.
        /// </summary>
        public void DeactivateUser(int userId)
        {
            _userRepository.Deactivate(userId);
        }

        /// <summary>
        /// جلب جميع المستخدمين.
        /// </summary>
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}