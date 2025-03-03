using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Data;
using TaskManagementApi.DTOs.Task;
using TaskManagementApi.Entities;
using TaskManagementApi.Helpers;

namespace TaskManagementApi.Services
{
    public class TaskService(AppDBContext context) : ITaskService
    {
        public required AppDBContext _context = context;

        public async Task<List<ProjectTask>> GetAllTasksAsync(QueryObject query)
        {
            var tasks = _context.Tasks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                tasks = tasks.Where(t => t.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    tasks = query.IsDescending ? tasks.OrderByDescending(t => t.Name) : tasks.OrderBy(t => t.Name);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await tasks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
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

        public async Task<ProjectTask?> UpdateTaskAsync(int id, ProjectTask taskModel)
        {
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTask is null)
            {
                return null;
            }

            existingTask.Name = taskModel.Name;
            existingTask.Description = taskModel.Description;
            existingTask.Status = taskModel.Status;
            existingTask.DueDate = taskModel.DueDate;

            await _context.SaveChangesAsync();

            return existingTask;
        }

        public async Task<ProjectTask?> DeleteTaskAsync(int id)
        {
            var taskModel = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (taskModel is null)
            {
                return null;
            }

            _context.Remove(taskModel);
            await _context.SaveChangesAsync();

            return taskModel;
        }
    }
}
