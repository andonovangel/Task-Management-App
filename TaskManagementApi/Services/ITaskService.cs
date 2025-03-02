using TaskManagementApi.Entities;

namespace TaskManagementApi.Services
{
    public interface ITaskService
    {
        Task<List<ProjectTask>> GetAllTasksAsync();
        Task<ProjectTask?> GetTaskByIdAsync(int id);
        Task<ProjectTask?> CreateTaskAsync(ProjectTask taskModel);
    }
}
