using TaskManagementApi.DTOs.Task;

namespace TaskManagementApi.DTOs.Project
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public List<TaskDTO> Tasks { get; set; }
    }
}
