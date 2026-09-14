
using KanbanProjectManagementSystem.Common.Entities;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class ProjectDetailsForm : Form
    {
        private readonly ProjectService _projectService = new();
        private Project? _project;

        public ProjectDetailsForm(int? projectId = null)
        {
            InitializeComponent();
            if (projectId.HasValue)
            {
                _project = _projectService.GetProjectsForUser(
                    SessionManager.CurrentUser!.UserID, SessionManager.CurrentUser.RoleID)
                    .Find(p => p.ProjectID == projectId.Value);
                LoadProject();
            }
            else
            {
                _project = new Project();
            }
        }

        private void LoadProject()
        {
            if (_project == null) return;
            txtProjectName.Text = _project.ProjectName;
            txtDescription.Text = _project.Description;
            dtpStartDate.Value = _project.StartDate;
            if (_project.ExpectedEndDate.HasValue)
            {
                dtpEndDate.Value = _project.ExpectedEndDate.Value;
                dtpEndDate.Checked = true;
            }
            cmbStatus.SelectedItem = _project.Status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_project == null) _project = new Project();

                _project.ProjectName = txtProjectName.Text.Trim();
                _project.Description = txtDescription.Text.Trim();
                _project.StartDate = dtpStartDate.Value;
                _project.ExpectedEndDate = dtpEndDate.Checked ? dtpEndDate.Value : null;
                _project.Status = cmbStatus.SelectedItem?.ToString() ?? "New";
                _project.CreatedBy = SessionManager.CurrentUser!.UserID;

                if (_project.ProjectID == 0)
                    _projectService.CreateProject(_project);
                else
                    _projectService.UpdateProject(_project);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}