using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tasks;
using TaskManagerSM.Db;
using TaskManagerSM.ViewModel.Tasks;

namespace TaskManagerSM.DataAccess.DbImplementation.Tasks
{
    public class UpdateTaskCommand : IUpdateTaskCommand
    {
        private TasksContext _context { get; }
        public UpdateTaskCommand(TasksContext context)
        {
            _context = context;
        }

        public async Task<TaskResponse> ExecuteAsync(UpdateTaskRequest request, int taskId)
        {
            var task = await _context.Tasks
                //.Include(t => t.Tags)
                //.Include(p => p.Project)
                .FirstOrDefaultAsync(t => t.Id == taskId);
            if (task == null)
            {
                throw new Exception("Такой задачи не существует не существует");
            }

            task = Mapper.Map<Entities.Task>(request);//у реквеста нет проджекта. добавить проджект на таск

            task.Project = await _context.Projects
                //.Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == task.ProjectId);

            foreach (var tagsInTask in task.Tags)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tagsInTask.Tag.Name);
                if (tag != null) tagsInTask.Tag = tag;
            }

            await _context.SaveChangesAsync();
            

            var response = Mapper.Map<TaskResponse>(task);
            return response;

        }
    }
}
