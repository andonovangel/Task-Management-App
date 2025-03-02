namespace TaskManagementApi.DTOs.Project
{
    public class CreateProjectRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
    }
}
