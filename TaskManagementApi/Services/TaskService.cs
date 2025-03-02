using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Data;
using TaskManagementApi.Entities;

namespace TaskManagementApi.Services
{
    public class TaskService(AppDBContext context) : ITaskService
    {
        public required AppDBContext _context = context;

        public async Task<List<ProjectTask>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<ProjectTask?> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<ProjectTask?> CreateTaskAsync(ProjectTask taskModel)
        {
            await _context.Tasks.AddAsync(taskModel);
            await _context.SaveChangesAsync();

            return taskModel;
        }
    }
}
