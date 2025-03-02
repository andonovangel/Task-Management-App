namespace TaskManagementApi.DTOs.Project
{
    public class UpdateProjectRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
    }
}
