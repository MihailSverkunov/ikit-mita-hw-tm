using System.Threading.Tasks;
using TaskManagerSM.Db;
using TaskManagerSM.Entities;
using TaskManagerSM.ViewModel.Projects;
using AutoMapper;
using TaskManagerSM.DataAccess.Projects;

namespace TaskManagerSM.DataAccess.DbImplementation.Projects
{
    internal class CreateProjectCommand : ICreateProjectCommand
    {
       
        private TasksContext _context { get; }
        public CreateProjectCommand(TasksContext context)
        {
            _context = context;
        }
        public async Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request)
        {
                       
            var project = Mapper.Map<Project>(request);

            
               // .ForMember("OpenTasksCount", opt => opt.MapFrom(src => 0)));
            ProjectResponse projectResponse = Mapper.Map<ProjectResponse>(project);

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();



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