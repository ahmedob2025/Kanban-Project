using KanbanProjectManagementSystem.Common.Entities;
using KanbanProjectManagementSystem.DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// خدمة لوحة Kanban.
    /// </summary>
    public class KanbanService
    {
        private readonly TaskRepository _taskRepository;

        public KanbanService()
        {
            _taskRepository = new TaskRepository();
        }

        /// <summary>
        /// جلب المهام مصنفة حسب الحالة.
        /// </summary>
        public (List<KanbanTask> newTasks, List<KanbanTask> inProgressTasks, List<KanbanTask> doneTasks) GetBoardTasks(int projectId)
        {
            var allTasks = _taskRepository.GetTasksByProject(projectId);
            return (
                allTasks.Where(t => t.Status == "New").ToList(),
                allTasks.Where(t => t.Status == "InProgress").ToList(),
                allTasks.Where(t => t.Status == "Done").ToList()
            );
        }
    }
}