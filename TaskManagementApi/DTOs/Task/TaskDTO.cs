namespace TaskManagementApi.DTOs.Task
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }
        public int? ProjectId { get; set; }
    }
}
