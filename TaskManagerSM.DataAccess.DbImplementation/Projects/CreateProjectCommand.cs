using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Projects;
using TaskManagerSM.Db;
using TaskManagerSM.Entities;
using TaskManagerSM.ViewModel.Projects;
using AutoMapper;

namespace TaskManagerSM.DataAccess.DbImplementation.Projects
{
    public class CreateProjectCommand : ICreateProjectCommand
    {
        private TasksContext Context { get; }
        public CreateProjectCommand(TasksContext context)
        {
            Context = context;
        }

        public async Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request)
        {
            //AutoMapper очень удобно
            Mapper.Initialize(cfg => cfg.CreateMap<CreateProjectRequest, Project>());
            var project = Mapper.Map<Project>(request);

            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectResponse>()
                .ForMember("OpenTasksCount", opt => opt.MapFrom(src => 0)));
            ProjectResponse projectResponse = Mapper.Map<ProjectResponse>(project);

            await Context.Projects.AddAsync(project);
            await Context.SaveChangesAsync();

            

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