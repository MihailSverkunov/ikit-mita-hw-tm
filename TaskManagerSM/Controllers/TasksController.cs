using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagerSM.ViewModel;
using TaskManagerSM.ViewModel.Tasks;
using TaskManagerSM.DataAccess.Tasks;

namespace TaskManagerSM.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ListResponse<TaskResponse>))]
        public async Task<IActionResult> GetTasksListAsync(TaskFilter filter, ListOptions options)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(TaskResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTaskAsync([FromBody]CreateTaskRequest request, [FromServices]ICreateTaskCommand command)
        //[FromBody]CreateProjectRequest request, [FromServices]ICreateProjectCommand command
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //TaskResponse response = await command.ExecuteAsync(request);
            try
            {
                TaskResponse response = await command.ExecuteAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{taskId}")]
        [ProducesResponseType(200, Type = typeof(TaskResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTaskAsync(int taskId, [FromServices]ITaskQuery query)
        {
            try
            {
                TaskResponse response = await query.RunAsync(taskId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return response == null
            //    ? (IActionResult)NotFound()
            //    : Ok(response);
        }

        [HttpPut("{taskId}")]
        [ProducesResponseType(200, Type = typeof(TaskResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTaskAsync(int taskId, [FromBody]UpdateTaskRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            throw new NotImplementedException();
        }

        [HttpDelete("{taskId}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTaskAsync(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}