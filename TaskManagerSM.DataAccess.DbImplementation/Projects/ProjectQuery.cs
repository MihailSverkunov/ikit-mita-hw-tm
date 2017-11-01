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
using TaskManagerSM.DataAccess.UnitOfWork;

namespace TaskManagerSM.DataAccess.DbImplementation.Projects
{
    public class ProjectQuery : IProjectQuery
    {
        private IUnitOfWork Uow { get; }
        public ProjectQuery(IUnitOfWork uow)
        {
            Uow = uow;
        }

        public async Task<ProjectResponse> RunAsync(int projectId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectResponse>()
                                        .ForMember("OpenTasksCount", otc => otc.MapFrom(src => src.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed))));

            ProjectResponse response = await Uow.Projects
                .Select(p => Mapper.Map<ProjectResponse>(p))
                //{
                //    Id = p.Id,
                //    Name = p.Name,
                //    Description = p.Description,
                //    OpenTasksCount = p.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed)
                //}

                .FirstOrDefaultAsync(pr => pr.Id == projectId);

            

            return response;
        }
    }
}