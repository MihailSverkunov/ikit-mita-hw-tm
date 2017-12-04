using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tasks;
using TaskManagerSM.Db;

using TaskManagerSM.ViewModel.Tasks;

namespace TaskManagerSM.DataAccess.DbImplementation.Tasks
{
    internal class CreateTaskCommand : ICreateTaskCommand
    {

        private TasksContext _context { get; }
        public CreateTaskCommand(TasksContext context)
        {
            _context = context;
        }
        public async Task<TaskResponse> ExecuteAsync(CreateTaskRequest request)
        {

            var project = await _context.Projects.FindAsync(request.ProjectId);

            if (project == null)
            {
                throw new Exception("Такого пользователя не существует, проверте правильность ID");
            }

            Entities.Task task = Mapper.Map<Entities.Task>(request);
           
            
            foreach (var tagsInTask in task.Tags)
            {                
                var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tagsInTask.Tag.Name);
                if (tag != null) tagsInTask.Tag = tag;
            }


            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();


            TaskResponse response = Mapper.Map<TaskResponse>(task);

            return response;
            //{
            //    Id = project.Id,
            //    Name = project.Name,
            //    Description = project.Description,
            //    OpenTasksCount = 0
            //};
        }

    }
}

