﻿using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
