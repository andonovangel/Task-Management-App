using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.DTOs.Task
{
    public class UpdateTaskRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
