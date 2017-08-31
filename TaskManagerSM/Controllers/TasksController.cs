using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagerSM.ViewModel;
using TaskManagerSM.ViewModel.Tasks;

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
        public async Task<IActionResult> CreateTaskAsync([FromBody]CreateTaskRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            throw new NotImplementedException();
        }

        [HttpGet("{taskId}")]
        [ProducesResponseType(200, Type = typeof(TaskResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTaskAsync(int taskId)
        {
            throw new NotImplementedException();
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