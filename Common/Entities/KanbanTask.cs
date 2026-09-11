namespace KanbanProjectManagementSystem.Common.Entities
{
    public class KanbanTask
    {
        public int TaskID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ProjectID { get; set; }
        public int? ParentTaskID { get; set; }
        public int? AssignedTo { get; set; }
        public int Priority { get; set; } = 2;
        public string Status { get; set; } = "New";
        public DateTime? DueDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; }
    }
}