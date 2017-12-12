using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tasks;
using TaskManagerSM.Db;
using TaskManagerSM.Entities;
using TaskManagerSM.ViewModel.Tasks;

namespace TaskManagerSM.DataAccess.DbImplementation.Tasks
{
    public class AddTagToTaskCommand : IAddTagToTaskCommand
    {
        private TasksContext _context { get; }
        public AddTagToTaskCommand(TasksContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<TaskResponse> ExecuteAsync(int taskId, string tagName)
        {
            var task = await _context.Tasks
                .Include(t => t.Tags).ThenInclude(tt => tt.Tag)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(pr => pr.Id == taskId);

            if (task == null) throw new Exception("Нет такой задачи");

            var tag =  await _context.Tags.FirstOrDefaultAsync(t => t.Name == tagName);
            if (tag == null)
            {
                tag = new Tag { Name = tagName };

                task.Tags.Add(new Entities.TagsInTask
                {
                    Tag = tag,
                    TagId = tag.Id,
                    Task = task,
                    TaskId = task.Id
                });
            }
            else
            {
                foreach (var tagInTask in task.Tags)
                {
                    if (tagInTask.Tag.Name == tagName)
                        throw new Exception("Такой тэг уже есть в задаче");
                }

                task.Tags.Add(new Entities.TagsInTask
                {
                    Tag = tag,
                    TagId = tag.Id,
                    Task = task,
                    TaskId = task.Id
                });
            }
            await _context.SaveChangesAsync();
            var response = Mapper.Map<TaskResponse>(task);
            return response;

        }
    }
}

