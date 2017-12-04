using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tasks;
using TaskManagerSM.Db;

namespace TaskManagerSM.DataAccess.DbImplementation.Tasks
{
    public class DeleteTagFromTaskCommand : IDeleteTagFromTaskCommand
    {
        private TasksContext _context { get; }
        public DeleteTagFromTaskCommand(TasksContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync(int taskId, string Tag)
        {
            var tit = await _context.TagsInTasks
                .Where(t => t.TaskId == taskId)
                .FirstOrDefaultAsync(t => t.Tag.Name == Tag);
            if (tit != null)
            {
                _context.TagsInTasks.Remove(tit);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Проверте правильность ввода!");
            }

            var tagToDelete = await _context.Tags.FirstOrDefaultAsync(t => t.Name == Tag);

            if (tagToDelete.TasksCount == 0)
            {
                _context.Tags.Remove(tagToDelete);
                await _context.SaveChangesAsync();
            }

            return;
        }
    }
}
