

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class ProjectsForm : Form
    {
        private readonly ProjectService _projectService = new();

        public ProjectsForm()
        {
            InitializeComponent();
            LoadProjects();
        }

        private void LoadProjects()
        {
            var user = SessionManager.CurrentUser;
            if (user == null) return;
            dgvProjects.DataSource = _projectService.GetProjectsForUser(user.UserID, user.RoleID);
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            using var frm = new ProjectDetailsForm();
            if (frm.ShowDialog() == DialogResult.OK) LoadProjects();
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مشروعاً أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvProjects.SelectedRows[0].Cells["ProjectID"].Value);
            using var frm = new ProjectDetailsForm(id);
            if (frm.ShowDialog() == DialogResult.OK) LoadProjects();
        }

        /// <summary>
        /// فتح واجهة إدارة المهام للمشروع المحدد.
        /// </summary>
        private void btnManageTasks_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مشروعاً من القائمة أولاً لإدارة مهامه.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int projectId = Convert.ToInt32(dgvProjects.SelectedRows[0].Cells["ProjectID"].Value);
            new TasksManagementForm(projectId).Show();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مشروعاً أولاً.");
                return;
            }
            int id = Convert.ToInt32(dgvProjects.SelectedRows[0].Cells["ProjectID"].Value);
            new ProjectMembersForm(id).Show();
        }

        private void btnOpenBoard_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مشروعاً أولاً.");
                return;
            }
            int id = Convert.ToInt32(dgvProjects.SelectedRows[0].Cells["ProjectID"].Value);
            new KanbanBoardForm(id).Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر مشروعاً أولاً.");
                return;
            }
            int id = Convert.ToInt32(dgvProjects.SelectedRows[0].Cells["ProjectID"].Value);
            new ProjectReportsForm(id).Show();
        }
    }
}