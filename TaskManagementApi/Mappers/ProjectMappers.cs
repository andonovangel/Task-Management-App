using TaskManagementApi.DTOs.Project;
using TaskManagementApi.Entities;

namespace TaskManagementApi.Mappers
{
    public static class ProjectMappers
    {
        public static ProjectDTO ToProjectDTO(this Project projectModel)
        {
            return new ProjectDTO
            {
                Id = projectModel.Id,
                Name = projectModel.Name,
                Description = projectModel.Description,
                DueDate = projectModel.DueDate,
                Tasks = projectModel.Tasks.Select(t => t.ToTaskDTO()).ToList()
            };
        }

        public static Project ToProjectFromCreateDTO(this CreateProjectRequestDTO projectDTO)
        {
            return new Project
            {
                Name = projectDTO.Name,
                Description = projectDTO.Description,
                DueDate = projectDTO.DueDate
            };
        }

        public static Project ToProjectFromUpdateDTO(this UpdateProjectRequestDTO projectDTO)
        {
            return new Project
            {
                Name = projectDTO.Name,
                Description = projectDTO.Description,
                DueDate = projectDTO.DueDate
            };
        }
    }
}
