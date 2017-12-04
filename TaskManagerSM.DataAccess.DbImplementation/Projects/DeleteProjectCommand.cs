using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Projects;
using TaskManagerSM.Db;
using TaskManagerSM.Entities;

namespace TaskManagerSM.DataAccess.DbImplementation.Projects
{
    public class DeleteProjectCommand : IDeleteProjectCommand
    {
        private TasksContext _context { get; }
        public DeleteProjectCommand(TasksContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task ExecuteAsync(int projectId)
        {
            Project project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
            if (project != null)
            {
                if (project.OpenTasksCount != 0) throw new CannotDeleteProjectWithTasksException();

                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Такого пользователя не существует");
            }
        }
    }
}
