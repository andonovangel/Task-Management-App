﻿using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.DTOs.Auth
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
