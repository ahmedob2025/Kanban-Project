namespace KanbanProjectManagementSystem.Common.Entities
{
    public class ProjectMember
    {
        public int ProjectMemberID { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.Now;
    }
}