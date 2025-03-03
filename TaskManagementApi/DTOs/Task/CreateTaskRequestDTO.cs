using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.DTOs.Task
{
    public class CreateTaskRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public DateTime DueDate { get; set; }
    }
}
