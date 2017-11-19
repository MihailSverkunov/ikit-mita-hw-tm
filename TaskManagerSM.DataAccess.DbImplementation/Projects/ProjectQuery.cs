using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagerSM.DataAccess.Projects;
using TaskManagerSM.Db;
using TaskManagerSM.Entities;
using TaskManagerSM.ViewModel.Projects;
using AutoMapper;


namespace TaskManagerSM.DataAccess.DbImplementation.Projects
{
    public class ProjectQuery : IProjectQuery
    {
        private TasksContext _context { get; }
        public ProjectQuery(TasksContext context)
        {
            _context = context;
        }

        public async Task<ProjectResponse> RunAsync(int projectId)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectResponse>()
                                       // .ForMember("OpenTasksCount", otc => otc.MapFrom(src => src.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed))));

            ProjectResponse response = await _context.Projects
                .Select(p => Mapper.Map<ProjectResponse>(p))
                .FirstOrDefaultAsync(pr => pr.Id == projectId);
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