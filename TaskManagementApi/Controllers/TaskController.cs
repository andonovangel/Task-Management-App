using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.DTOs.Task;
using TaskManagementApi.Mappers;
using TaskManagementApi.Services;

namespace TaskManagementApi.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController(ITaskService taskService, IProjectService projectService) : ControllerBase
    {
        private readonly ITaskService _taskService = taskService;
        private readonly IProjectService _projectService = projectService;


        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();

            var taskDTO = tasks.Select(t => t.ToTaskDTO());

            return Ok(taskDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById([FromRoute] int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task is null)
            {
                return NotFound();
            }

            return Ok(task.ToTaskDTO());
        }

        [HttpPost("{projectId}")]
        public async Task<IActionResult> CreateTask([FromRoute] int projectId, [FromBody] CreateTaskRequestDTO taskDTO)
        {
            if (!await _projectService.ProjectExists(projectId))
            {
                return BadRequest("Project does not exist");
            }

            var taskModel = taskDTO.ToTaskFromCreateDTO(projectId);
            await _taskService.CreateTaskAsync(taskModel);

            return CreatedAtAction(nameof(GetTaskById), new { id = taskModel.Id }, taskModel.ToTaskDTO());
        }
    }
}
