using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagerSM.ViewModel;
using TaskManagerSM.ViewModel.Tags;
using TaskManagerSM.DataAccess.Tags;

namespace TaskManagerSM.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ListResponse<TagResponse>))]
        public async Task<IActionResult> GetProjectsListAsync(TagFilter filter, ListOptions options, [FromServices]ITagsListQuery query)
        {
            try
            {
                var response = await query.RunAsync(filter, options);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("{tag}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTagAsync(string tag, [FromServices]IDeleteTagCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await command.ExecuteAsync(tag);
                return Ok("Успешно");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}