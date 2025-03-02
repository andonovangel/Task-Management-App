using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Data;
using TaskManagementApi.DTOs.Project;
using TaskManagementApi.Mappers;
using TaskManagementApi.Services;

namespace TaskManagementApi.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController(AppDBContext context, IProjectService projectService) : Controller
    {
        private readonly AppDBContext _cotnext = context;
        private readonly IProjectService _projectService = projectService;

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
                
            var projectDTO = projects.Select(s => s.ToProjectDTO());
            
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById([FromRoute] int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project is null)
            {
                return NotFound();
            }
            return Ok(project.ToProjectDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequestDTO projectDTO)
        {
            var projectModel = projectDTO.ToProjectFromCreateDTO();
            await _projectService.CreateProjectAsync(projectModel);
            return CreatedAtAction(nameof(GetProjectById), new { id = projectModel.Id }, projectModel.ToProjectDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromRoute] int id, [FromBody] UpdateProjectRequestDTO projectDTO)
        {
            var projectModel = await _projectService.UpdateProjectAsync(id, projectDTO);
            if (projectModel is null)
            {
                return NotFound();
            }

            return Ok(projectModel.ToProjectDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            var projectModel = await _projectService.DeleteProjectAsync(id);
            if (projectModel is null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
