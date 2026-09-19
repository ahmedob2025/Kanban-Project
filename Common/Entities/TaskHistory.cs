namespace KanbanProjectManagementSystem.Common.Entities
{
    public class TaskHistory
    {
        public int HistoryID { get; set; }
        public int TaskID { get; set; }
        public int UserID { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ActionDate { get; set; } = DateTime.Now;
    }
}