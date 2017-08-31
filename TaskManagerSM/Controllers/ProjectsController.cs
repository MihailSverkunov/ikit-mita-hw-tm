using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagerSM.DataAccess.Projects;
using TaskManagerSM.ViewModel;
using TaskManagerSM.ViewModel.Projects;

namespace TaskManagerSM.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ListResponse<ProjectResponse>))]
        public async Task<IActionResult> GetProjectsListAsync(ProjectFilter filter, ListOptions options, [FromServices]IProjectsListQuery query)
        {
            var response = await query.RunAsync(filter, options);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProjectResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateProjectAsync([FromBody]CreateProjectRequest request, [FromServices]ICreateProjectCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ProjectResponse response = await command.ExecuteAsync(request);
            return Ok(response); // This is wrong, it should return 401
        }

        [HttpGet("{projectId}")]
        [ProducesResponseType(200, Type = typeof(ProjectResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProjectAsync(int projectId, [FromServices]IProjectQuery query)
        {
            ProjectResponse response = await query.RunAsync(projectId);
            return response == null
                ? (IActionResult)NotFound()
                : Ok(response);
        }

        [HttpPut("{projectId}")]
        [ProducesResponseType(200, Type = typeof(ProjectResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public Task<IActionResult> UpdateProjectAsync(int projectId, [FromBody]UpdateProjectRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{projectId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public Task<IActionResult> DeleteProjectAsync(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}