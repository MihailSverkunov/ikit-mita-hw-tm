using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Projects;
using TaskManagerSM.Db;
using TaskManagerSM.Entities;
using TaskManagerSM.ViewModel.Projects;

namespace TaskManagerSM.DataAccess.DbImplementation.Projects
{
    public class UpdateProjectCommand : IUpdateProjectCommand
    {
        private TasksContext _context { get; }
        public UpdateProjectCommand(TasksContext context)
        {
            _context = context;
        }

        public async Task<ProjectResponse> ExecuteAsync(int projectId, UpdateProjectRequest request)
        {
            Project project = await _context.Projects.FindAsync(projectId);
            if (project == null) return null;

            project = Mapper.Map<Project>(request);

            await _context.SaveChangesAsync();

            return Mapper.Map<ProjectResponse>(project);
        }
    }
}


