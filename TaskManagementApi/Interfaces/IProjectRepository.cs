﻿using TaskManagementApi.Entities;
using TaskManagementApi.DTOs.Project;

namespace TaskManagementApi.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(Project projectModel);
        Task<Project?> UpdateProjectAsync(int id, Project projectModel);
        Task<Project?> DeleteProjectAsync(int id);
        Task<bool> ProjectExists(int id);
    }
}
