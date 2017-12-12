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
        public async Task<IActionResult> GetTasksListAsync(TaskFilter filter, ListOptions options, [FromServices]ITasksListQuery query)
        {
            var response = await query.RunAsync(filter, options);
            return Ok(response);
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
        public async Task<IActionResult> UpdateTaskAsync(int taskId, [FromBody]UpdateTaskRequest request, [FromServices]IUpdateTaskCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                TaskResponse response = await command.ExecuteAsync(request, taskId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{taskId}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTaskAsync(int taskId, [FromServices]IDeleteTaskCommand command)
        {
            try
            {
                await command.ExecuteAsync(taskId);
                return Ok("Успешно");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{taskId}/tags/{tag}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddTagToTaskAsync(int taskId, string tag, [FromServices]IAddTagToTaskCommand command)
        {
            try
            {
                var response = await command.ExecuteAsync(taskId, tag);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{taskId}/tags/{tag}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTagFromTaskAsync(int taskId, string tag, [FromServices]IDeleteTagFromTaskCommand command)
        {
            try
            {
                var response = await command.ExecuteAsync(taskId, tag);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}