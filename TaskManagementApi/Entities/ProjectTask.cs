namespace TaskManagementApi.Entities
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public DateTime DueDate { get; set; }
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
