using TaskManagementApi.Entities;
using TaskManagementApi.DTOs.Project;

namespace TaskManagementApi.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(Project projectModel);
        Task<Project?> UpdateProjectAsync(int id, UpdateProjectRequestDTO request);
        Task<Project?> DeleteProjectAsync(int id);
        Task<bool> ProjectExists(int id);
    }
}
