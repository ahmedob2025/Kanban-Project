

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class UsersManagementForm : Form
    {
        private readonly UserService _userService = new();

        public UsersManagementForm()
        {
            InitializeComponent();

            // BR-10: التحقق من صلاحية الأدمن فقط
            if (SessionManager.CurrentUser?.RoleID != 1)
            {
                MessageBox.Show("غير مصرح لك بالوصول إلى هذه الصفحة.", "صلاحيات",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }

            LoadUsers();
        }

        /// <summary>
        /// تحميل قائمة المستخدمين مع فلترة البحث.
        /// </summary>
        private void LoadUsers()
        {
            var users = _userService.GetAllUsers();
            var search = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(search))
            {
                users = users.Where(u =>
                    u.Username.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    u.FullName.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            dgvUsers.DataSource = users;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadUsers();

        /// <summary>
        /// إضافة مستخدم جديد — يفتح AddEditUserForm في وضع الإضافة.
        /// </summary>
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using var frm = new AddEditUserForm();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadUsers();
        }

        /// <summary>
        /// تعديل المستخدم المحدد — يفتح AddEditUserForm في وضع التعديل.
        /// </summary>
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مستخدماً من الجدول أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            var user = _userService.GetAllUsers().FirstOrDefault(u => u.UserID == userId);

            if (user == null)
            {
                MessageBox.Show("المستخدم غير موجود.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var frm = new AddEditUserForm(user);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadUsers();
        }

        /// <summary>
        /// تعطيل المستخدم المحدد (FR-04).
        /// </summary>
        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مستخدماً من الجدول أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            string username = dgvUsers.SelectedRows[0].Cells["Username"].Value?.ToString() ?? "";

            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("لا يمكن تعطيل حساب المدير الرئيسي.", "ممنوع",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"هل تريد تعطيل المستخدم \"{username}\"؟",
                "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _userService.DeactivateUser(userId);
                LoadUsers();
                MessageBox.Show("تم تعطيل المستخدم.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}