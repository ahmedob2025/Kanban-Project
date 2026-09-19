

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationService _authService = new();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _authService.Login(txtUsername.Text.Trim(), txtPassword.Text);
                if (user != null)
                {
                    SessionManager.CurrentUser = user;
                    Hide();
                    new DashboardForm().Show();
                }
                else
                {
                    MessageBox.Show("بيانات الدخول غير صحيحة أو الحساب معطل.", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}