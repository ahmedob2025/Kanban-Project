
using KanbanProjectManagementSystem.Common.Entities;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    /// <summary>
    /// نموذج إضافة / تعديل مستخدم.
    /// يغطي المتطلبات FR-02 (إنشاء مستخدم) و FR-03 (تعديل مستخدم).
    /// </summary>
    public partial class AddEditUserForm : Form
    {
        private readonly UserService _userService = new();
        private readonly User? _existingUser;
        private readonly bool _isEditMode;

        /// <summary>
        /// مُنشئ النموذج.
        /// </summary>
        /// <param name="user">إذا مُرِّر مستخدم، نكون في وضع التعديل؛ وإلا نكون في وضع الإضافة.</param>
        public AddEditUserForm(User? user = null)
        {
            InitializeComponent();

            _existingUser = user;
            _isEditMode = user != null;

            LoadRoles();

            if (_isEditMode)
            {
                this.Text = "تعديل مستخدم";
                lblTitle.Text = "تعديل بيانات المستخدم";
                txtUsername.Text = user!.Username;
                txtUsername.ReadOnly = true;    // لا يمكن تغيير اسم المستخدم
                txtFullName.Text = user.FullName;
                txtEmail.Text = user.Email;
                cmbRole.SelectedValue = user.RoleID;
                chkIsActive.Checked = user.IsActive;
                txtPassword.Enabled = false;    // لا يتم تعديل كلمة المرور هنا
                lblPasswordNote.Visible = true;
            }
            else
            {
                this.Text = "إضافة مستخدم";
                lblTitle.Text = "إضافة مستخدم جديد";
                chkIsActive.Checked = true;
                lblPasswordNote.Visible = false;
            }
        }

        /// <summary>
        /// تعبئة قائمة الأدوار.
        /// </summary>
        private void LoadRoles()
        {
            var roles = new[]
            {
                new { RoleID = 1, RoleName = "مدير النظام (Administrator)" },
                new { RoleID = 2, RoleName = "قائد مشروع (ProjectLeader)" },
                new { RoleID = 3, RoleName = "عضو فريق (TeamMember)" }
            };

            cmbRole.DataSource = roles;
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleID";
        }

        /// <summary>
        /// حفظ البيانات (إضافة أو تعديل).
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // التحقق من المدخلات الأساسية
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                    throw new Exception("اسم المستخدم مطلوب.");
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                    throw new Exception("الاسم الكامل مطلوب.");
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                    throw new Exception("البريد الإلكتروني مطلوب.");

                if (_isEditMode && _existingUser != null)
                {
                    // ===== وضع التعديل =====
                    _existingUser.FullName = txtFullName.Text.Trim();
                    _existingUser.Email = txtEmail.Text.Trim();
                    _existingUser.RoleID = (int)cmbRole.SelectedValue!;
                    _existingUser.IsActive = chkIsActive.Checked;

                    _userService.UpdateUser(_existingUser);

                    MessageBox.Show("تم تحديث بيانات المستخدم بنجاح.",
                        "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ===== وضع الإضافة =====
                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                        throw new Exception("كلمة المرور مطلوبة.");
                    if (txtPassword.Text.Length < 6)
                        throw new Exception("كلمة المرور يجب أن تكون 6 أحرف على الأقل.");

                    var newUser = new User
                    {
                        Username = txtUsername.Text.Trim(),
                        FullName = txtFullName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        RoleID = (int)cmbRole.SelectedValue!,
                        IsActive = chkIsActive.Checked
                    };

                    _userService.CreateUser(newUser, txtPassword.Text);

                    MessageBox.Show("تم إنشاء المستخدم بنجاح.",
                        "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// إلغاء العملية وإغلاق النموذج.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}