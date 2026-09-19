using KanbanProjectManagementSystem.Common.Entities;
using KanbanProjectManagementSystem.DataAccessLayer;

namespace BusinessLogicLayer
{
    public static class ValidationHelper
    {
        public static List<string> ValidateTask(
            KanbanTask task,
            ProjectRepository projectRepo,
            TaskRepository taskRepo)
        {
            var errors = new List<string>();

            if (task == null)
            {
                errors.Add("بيانات المهمة غير صحيحة.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(task.Title))
                errors.Add("عنوان المهمة مطلوب.");

            // التحقق من المشروع (مع حماية من الأخطاء)
            try
            {
                var project = projectRepo.GetById(task.ProjectID);
                if (project == null)
                    errors.Add("المشروع غير موجود.");
            }
            catch (Exception ex)
            {
                errors.Add($"تعذر التحقق من المشروع: {ex.Message}");
                return errors;
            }

            // التحقق من العضوية [BR-02]
            if (task.AssignedTo.HasValue)
            {
                try
                {
                    bool isMember = projectRepo.IsUserMemberOfProject(task.ProjectID, task.AssignedTo.Value);
                    if (!isMember)
                        errors.Add("لا يمكن إسناد المهمة لمستخدم غير عضو في المشروع.");
                }
                catch (Exception ex)
                {
                    errors.Add($"تعذر التحقق من عضوية المستخدم: {ex.Message}");
                }
            }

            // التحقق من الدورة الهرمية [BR-07]
            if (task.ParentTaskID.HasValue && task.TaskID > 0)
            {
                try
                {
                    if (WouldCreateCycle(task.ParentTaskID.Value, task.TaskID, taskRepo))
                        errors.Add("لا يمكن إنشاء علاقة هرمية دائرية بين المهام.");
                }
                catch { /* تجاهل */ }
            }

            // التحقق من التاريخ
            if (task.DueDate.HasValue)
            {
                DateTime compareDate = task.TaskID == 0
                    ? DateTime.Today
                    : task.CreatedDate.Date;

                if (task.DueDate.Value.Date < compareDate)
                    errors.Add("تاريخ الاستحقاق لا يجوز أن يسبق تاريخ الإنشاء.");
            }

            return errors;
        }

        public static bool CanCompleteTask(int taskId, TaskRepository taskRepo)
        {
            try
            {
                var subTasks = taskRepo.GetSubTasks(taskId);
                return subTasks == null || subTasks.All(st => st.Status == "Done");
            }
            catch
            {
                return true; // لا نمنع الإكمال عند الخطأ
            }
        }

        private static bool WouldCreateCycle(int parentTaskId, int currentTaskId, TaskRepository taskRepo)
        {
            int? currentParentId = parentTaskId;
            int safety = 0;

            while (currentParentId.HasValue && safety < 100)
            {
                if (currentParentId.Value == currentTaskId)
                    return true;

                var parentTask = taskRepo.GetById(currentParentId.Value);
                currentParentId = parentTask?.ParentTaskID;
                safety++;
            }

            return false;
        }
    }
}