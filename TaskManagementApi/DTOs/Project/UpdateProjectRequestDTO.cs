﻿using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.DTOs.Project
{
    public class UpdateProjectRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
    }
}
