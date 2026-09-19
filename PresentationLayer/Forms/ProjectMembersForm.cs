

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class ProjectMembersForm : Form
    {
        private readonly ProjectService _projectService = new();
        private readonly UserService _userService = new();
        private readonly int _projectId;

        public ProjectMembersForm(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            LoadData();
        }

        private void LoadData()
        {
            dgvMembers.DataSource = _projectService.GetProjectMembers(_projectId);

            var allUsers = _userService.GetAllUsers();
            var memberIds = _projectService.GetProjectMembers(_projectId)
                .ConvertAll(m => m.UserID);
            var available = allUsers.FindAll(u => !memberIds.Contains(u.UserID));

            cmbAvailableUsers.DataSource = available;
            cmbAvailableUsers.DisplayMember = "FullName";
            cmbAvailableUsers.ValueMember = "UserID";
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (cmbAvailableUsers.SelectedValue == null) return;
            try
            {
                int userId = (int)cmbAvailableUsers.SelectedValue;
                _projectService.AddMember(_projectId, userId);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}");
            }
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0) return;
            int userId = Convert.ToInt32(dgvMembers.SelectedRows[0].Cells["UserID"].Value);
            _projectService.RemoveMember(_projectId, userId);
            LoadData();
        }

    }
}