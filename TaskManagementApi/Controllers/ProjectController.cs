using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Data;
using TaskManagementApi.DTOs.Project;
using TaskManagementApi.Interfaces;
using TaskManagementApi.Mappers;

namespace TaskManagementApi.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController(AppDBContext context, IProjectRepository projectService) : Controller
    {
        private readonly AppDBContext _cotnext = context;
        private readonly IProjectRepository _projectService = projectService;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProjects()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projects = await _projectService.GetAllProjectsAsync();
                
            var projectDTO = projects.Select(s => s.ToProjectDTO());
            
            return Ok(projects);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProjectById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectModel = projectDTO.ToProjectFromCreateDTO();
            await _projectService.CreateProjectAsync(projectModel);
            return CreatedAtAction(nameof(GetProjectById), new { id = projectModel.Id }, projectModel.ToProjectDTO());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProject([FromRoute] int id, [FromBody] UpdateProjectRequestDTO projectDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectModel = await _projectService.UpdateProjectAsync(id, projectDTO.ToProjectFromUpdateDTO());
            if (projectModel is null)
            {
                return NotFound("Project not found.");
            }

            return Ok(projectModel.ToProjectDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectModel = await _projectService.DeleteProjectAsync(id);
            if (projectModel is null)
            {
                return NotFound("Project does not exist.");
            }

            return NoContent();
        }
    }
}
