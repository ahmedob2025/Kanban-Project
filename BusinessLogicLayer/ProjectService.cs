using KanbanProjectManagementSystem.Common.Entities;
using KanbanProjectManagementSystem.DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ProjectService
    {
        private readonly ProjectRepository _projectRepository;
        private readonly ProjectMemberRepository _projectMemberRepository;

        public ProjectService()
        {
            _projectRepository = new ProjectRepository();
            _projectMemberRepository = new ProjectMemberRepository();
        }

        public int CreateProject(Project project)
        {
            if (string.IsNullOrWhiteSpace(project.ProjectName))
                throw new Exception("اسم المشروع مطلوب.");
            if (project.ExpectedEndDate.HasValue && project.ExpectedEndDate.Value.Date < project.StartDate.Date)
                throw new Exception("تاريخ النهاية المتوقع لا يجوز أن يسبق تاريخ البداية.");

            return _projectRepository.Insert(project);
        }

        public void UpdateProject(Project project)
        {
            if (string.IsNullOrWhiteSpace(project.ProjectName))
                throw new Exception("اسم المشروع مطلوب.");
            if (project.ExpectedEndDate.HasValue && project.ExpectedEndDate.Value.Date < project.StartDate.Date)
                throw new Exception("تاريخ النهاية المتوقع لا يجوز أن يسبق تاريخ البداية.");

            _projectRepository.Update(project);
        }

        public List<Project> GetProjectsForUser(int userId, int roleId)
        {
            return _projectRepository.GetProjectsForUser(userId, roleId);
        }

        public void AddMember(int projectId, int userId)
        {
            _projectMemberRepository.AddMember(projectId, userId);
        }

        public void RemoveMember(int projectId, int userId)
        {
            _projectMemberRepository.RemoveMember(projectId, userId);
        }

        public List<ProjectMember> GetProjectMembers(int projectId)
        {
            return _projectMemberRepository.GetMembersByProject(projectId);
        }

        public List<User> GetProjectUsers(int projectId)
        {
            return _projectMemberRepository.GetUsersByProject(projectId);
        }
    }
}