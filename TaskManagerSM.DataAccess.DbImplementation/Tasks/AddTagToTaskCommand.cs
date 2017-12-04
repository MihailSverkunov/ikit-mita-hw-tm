using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tasks;
using TaskManagerSM.Db;

namespace TaskManagerSM.DataAccess.DbImplementation.Tasks
{
    public class AddTagToTaskCommand : IAddTagToTaskCommand
    {
        private TasksContext _context { get; }
        public AddTagToTaskCommand(TasksContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync(int taskId, string Tag)
        {
            var task = await _context.Tasks
                .Include(t => t.Tags).ThenInclude(tt => tt.Tag)
                //.Include(p => p.Project)
                .FirstOrDefaultAsync(pr => pr.Id == taskId);

            if (task == null) throw new Exception("Нет такой задачи");

            foreach (var tagInTask in task.Tags)
            {
                if (tagInTask.Tag.Name == Tag)
                    return;
            }

            var tag = new Entities.Tag { Name = Tag };
            task.Tags.Add(new Entities.TagsInTask
            {
                Tag = tag,
                TagId = tag.Id,
                Task = task,
                TaskId = task.Id
            });

            if (await _context.Tags.FirstOrDefaultAsync(t => t.Name == Tag) == null)
            {
                await _context.Tags.AddAsync(tag);
            }
            await _context.SaveChangesAsync();

            return;
        }
    }
}

