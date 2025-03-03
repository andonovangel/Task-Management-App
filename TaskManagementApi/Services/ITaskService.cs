using TaskManagementApi.DTOs.Task;
using TaskManagementApi.Entities;
using TaskManagementApi.Helpers;

namespace TaskManagementApi.Services
{
    public interface ITaskService
    {
        Task<List<ProjectTask>> GetAllTasksAsync(QueryObject query);
        Task<ProjectTask?> GetTaskByIdAsync(int id);
        Task<ProjectTask?> CreateTaskAsync(ProjectTask taskModel);
        Task<ProjectTask?> UpdateTaskAsync(int id, ProjectTask taskModel);
        Task<ProjectTask?> DeleteTaskAsync(int id);
    }
}
