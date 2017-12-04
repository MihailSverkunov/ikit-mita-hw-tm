using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tasks;
using TaskManagerSM.Db;
using TaskManagerSM.ViewModel.Tasks;

namespace TaskManagerSM.DataAccess.DbImplementation.Tasks
{
    public class TaskQuery : ITaskQuery
    {
        private TasksContext _context { get; }
        public TaskQuery(TasksContext context)
        {
            _context = context;
        }

        public async Task<TaskResponse> RunAsync(int taskId)
        {

            var task = await _context.Tasks                
                .Include(t => t.Tags).ThenInclude(tt => tt.Tag)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(pr => pr.Id == taskId);

            var response = Mapper.Map<TaskResponse>(task);

            return response;
        }
    }
}
