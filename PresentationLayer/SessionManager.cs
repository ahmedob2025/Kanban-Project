using KanbanProjectManagementSystem.Common.Entities;

namespace KanbanProjectManagementSystem.PresentationLayer
{
    public static class SessionManager
    {
        public static User? CurrentUser { get; set; }
    }
}