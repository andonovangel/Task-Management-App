using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.DTOs.Task;
using TaskManagementApi.Helpers;
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
        public async Task<IActionResult> GetAllTasks([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tasks = await _taskService.GetAllTasksAsync(query);

            var taskDTO = tasks.Select(t => t.ToTaskDTO());

            return Ok(taskDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTaskById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _taskService.GetTaskByIdAsync(id);

            if (task is null)
            {
                return NotFound();
            }

            return Ok(task.ToTaskDTO());
        }

        [HttpPost("{projectId:int}")]
        public async Task<IActionResult> CreateTask([FromRoute] int projectId, [FromBody] CreateTaskRequestDTO taskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _projectService.ProjectExists(projectId))
            {
                return BadRequest("Project does not exist.");
            }

            var taskModel = taskDTO.ToTaskFromCreateDTO(projectId);
            await _taskService.CreateTaskAsync(taskModel);

            return CreatedAtAction(nameof(GetTaskById), new { id = taskModel.Id }, taskModel.ToTaskDTO());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTask([FromRoute] int id, [FromBody] UpdateTaskRequestDTO taskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskModel = await _taskService.UpdateTaskAsync(id, taskDTO.ToTaskFromUpdateDTO());

            if (taskModel is null)
            {
                return NotFound("Task not found.");
            }

            return Ok(taskModel.ToTaskDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskModel = await _taskService.DeleteTaskAsync(id);

            if (taskModel is null)
            {
                return NotFound("Task does not exist.");
            }

            return NoContent();
        }
    }
}
