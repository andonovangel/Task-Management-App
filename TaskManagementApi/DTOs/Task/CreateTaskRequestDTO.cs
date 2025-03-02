namespace TaskManagementApi.DTOs.Task
{
    public class CreateTaskRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
