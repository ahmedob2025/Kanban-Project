using KanbanProjectManagementSystem.Common.Entities;
using KanbanProjectManagementSystem.DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// خدمة إدارة المهام.
    /// تتوافق مع FR-09 إلى FR-17 وFR-21.
    /// </summary>
    public class TaskService
    {
        private readonly TaskRepository _taskRepository;
        private readonly ProjectRepository _projectRepository;
        private readonly ActivityLogRepository _activityLogRepository;

        public TaskService()
        {
            _taskRepository = new TaskRepository();
            _projectRepository = new ProjectRepository();
            _activityLogRepository = new ActivityLogRepository();
        }

        public int CreateTask(KanbanTask task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            var errors = ValidationHelper.ValidateTask(task, _projectRepository, _taskRepository);
            if (errors.Any())
                throw new Exception(string.Join("\n", errors));

            int newTaskId = _taskRepository.Insert(task);

            try
            {
                _activityLogRepository.Insert(new TaskHistory
                {
                    TaskID = newTaskId,
                    UserID = task.CreatedBy,
                    ActionType = "Created",
                    Description = $"تم إنشاء المهمة: {task.Title}"
                });
            }
            catch { /* لا نُفشل الإنشاء بسبب فشل التسجيل */ }

            return newTaskId;
        }

        public void UpdateTask(KanbanTask task, int currentUserId)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            var errors = ValidationHelper.ValidateTask(task, _projectRepository, _taskRepository);
            if (errors.Any())
                throw new Exception(string.Join("\n", errors));

            _taskRepository.Update(task);

            try
            {
                _activityLogRepository.Insert(new TaskHistory
                {
                    TaskID = task.TaskID,
                    UserID = currentUserId,
                    ActionType = "Updated",
                    Description = $"تم تعديل المهمة: {task.Title}"
                });
            }
            catch { /* تجاهل */ }
        }

        public void DeleteTask(int taskId, int currentUserId)
        {
            _taskRepository.Delete(taskId);
            _activityLogRepository.Insert(new TaskHistory
            {
                TaskID = taskId,
                UserID = currentUserId,
                ActionType = "Deleted",
                Description = "تم حذف المهمة"
            });
        }

        public void ChangeStatus(int taskId, string newStatus, int currentUserId)
        {
            if (newStatus == "Done")
            {
                bool canComplete = ValidationHelper.CanCompleteTask(taskId, _taskRepository);
                if (!canComplete)
                    throw new Exception("لا يمكن إكمال المهمة الرئيسية قبل اكتمال جميع المهام الفرعية.");
            }

            _taskRepository.UpdateStatus(taskId, newStatus);
            _activityLogRepository.Insert(new TaskHistory
            {
                TaskID = taskId,
                UserID = currentUserId,
                ActionType = "StatusChanged",
                Description = $"تم تغيير الحالة إلى {newStatus}"
            });
        }

        public List<KanbanTask> GetTasksByProject(int projectId)
        {
            return _taskRepository.GetTasksByProject(projectId);
        }

        public KanbanTask? GetTaskById(int taskId)
        {
            return _taskRepository.GetById(taskId);
        }

        public List<KanbanTask> GetSubTasks(int parentTaskId)
        {
            return _taskRepository.GetSubTasks(parentTaskId);
        }

        /// <summary>
        /// جلب المهام المسندة لمستخدم معين.
        /// </summary>
        public List<KanbanTask> GetTasksByAssignedUser(int userId, int? projectId = null)
        {
            return _taskRepository.GetTasksByAssignedUser(userId, projectId);
        }
    }
}