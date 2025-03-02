using TaskManagementApi.DTOs.Task;
using TaskManagementApi.Entities;

namespace TaskManagementApi.Mappers
{
    public static class TaskMappers
    {
        public static TaskDTO ToTaskDTO(this ProjectTask taskModel)
        {
            return new TaskDTO
            {
                Id = taskModel.Id,
                Name = taskModel.Name,
                Description = taskModel.Description,
                Status = taskModel.Status,
                DueDate = taskModel.DueDate,
                ProjectId = taskModel.ProjectId
            };
        }

        public static ProjectTask ToTaskFromCreateDTO(this CreateTaskRequestDTO taskDTO, int projectId)
        {
            return new ProjectTask
            {
                Name = taskDTO.Name,
                Description = taskDTO.Description,
                Status = taskDTO.Status,
                DueDate = taskDTO.DueDate,
                ProjectId = projectId
            };
        }
    }
}
