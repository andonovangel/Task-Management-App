using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TaskManagementApi.Data;
using TaskManagementApi.Entities;
using TaskManagementApi.DTOs.Project;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Interfaces;

namespace TaskManagementApi.Repositories
{
    public class ProjectRepository(AppDBContext context) : IProjectRepository
    {
        private readonly AppDBContext _context = context;

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.Include(p => p.Tasks).ToListAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Project> CreateProjectAsync(Project projectModel)
        {
            await _context.Projects.AddAsync(projectModel);
            await _context.SaveChangesAsync();

            return projectModel;
        }

        public async Task<Project?> UpdateProjectAsync(int id, Project projectModel)
        {
            var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProject is null)
            {
                return null;
            }

            existingProject.Name = projectModel.Name;
            existingProject.Description = projectModel.Description;
            existingProject.DueDate = projectModel.DueDate;

            await _context.SaveChangesAsync();

            return existingProject;
        }

        public async Task<Project?> DeleteProjectAsync(int id)
        {
            var projectModel = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (projectModel is null)
            {
                return null;
            }

            _context.Remove(projectModel);
            await _context.SaveChangesAsync();

            return projectModel;
        }

        public async Task<bool> ProjectExists(int id)
        {
            return await _context.Projects.AnyAsync(p => p.Id == id);
        }
    }
}
