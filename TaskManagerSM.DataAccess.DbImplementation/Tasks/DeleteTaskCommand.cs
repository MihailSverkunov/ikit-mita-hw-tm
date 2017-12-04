using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tasks;
using TaskManagerSM.Db;

namespace TaskManagerSM.DataAccess.DbImplementation.Tasks
{
    public class DeleteTaskCommand : IDeleteTaskCommand
    {
        private TasksContext _context { get; }
        public DeleteTaskCommand(TasksContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync(int taskId)
        {
           
            var task = await _context.Tasks.FirstOrDefaultAsync(p => p.Id == taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Такой задачи не существует");
            }
        }
    }
}
