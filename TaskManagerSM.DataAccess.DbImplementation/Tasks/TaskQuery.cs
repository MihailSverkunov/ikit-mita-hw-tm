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


            TaskResponse response = await _context.Tasks
                .Select(t => Mapper.Map<TaskResponse>(t))
                .FirstOrDefaultAsync(pr => pr.Id == taskId);
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Description = p.Description,
            //    OpenTasksCount = p.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed)
            //}





            return response;
        }
    }
}
