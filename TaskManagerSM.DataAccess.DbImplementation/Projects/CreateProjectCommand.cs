using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Projects;
using TaskManagerSM.Db;
using TaskManagerSM.Entities;
using TaskManagerSM.ViewModel.Projects;
using AutoMapper;
using TaskManagerSM.DataAccess.UnitOfWork;

namespace TaskManagerSM.DataAccess.DbImplementation.Projects
{
    internal class CreateProjectCommand : ICreateProjectCommand
    {
        private IUnitOfWork Uow { get; }
        public CreateProjectCommand(IUnitOfWork uow)
        {
            Uow = uow;
        }
        public async Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request)
        {
            //AutoMapper очень удобно
            Mapper.Initialize(cfg => cfg.CreateMap<CreateProjectRequest, Project>());
            var project = Mapper.Map<Project>(request);

            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectResponse>()
                .ForMember("OpenTasksCount", opt => opt.MapFrom(src => 0)));
            ProjectResponse projectResponse = Mapper.Map<ProjectResponse>(project);

            Uow.Projects.Add(project);
            await Uow.CommitAsync();



            return projectResponse;
            //{
            //    Id = project.Id,
            //    Name = project.Name,
            //    Description = project.Description,
            //    OpenTasksCount = 0
            //};
        }
    }
}