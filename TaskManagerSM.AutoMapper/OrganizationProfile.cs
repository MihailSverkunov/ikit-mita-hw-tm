using AutoMapper;
using System;
using TaskManagerSM.Entities;
using TaskManagerSM.ViewModel.Projects;
using TaskManagerSM.ViewModel.Tasks;

namespace TaskManagerSM.AutoMapper
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
            Mapper.Initialize(cfg =>
            {
                //projects
                cfg.CreateMap<CreateProjectRequest, Project>();
                cfg.CreateMap<Project, ProjectResponse>();
                cfg.CreateMap<UpdateProjectRequest, Project>();

                //tasks
                cfg.CreateMap<CreateTaskRequest, Task>()
                            .ForMember("Status", opt => opt.UseValue(TaskStatus.Created));
                            //.ForMember("Tags", opt => opt.MapFrom);

                cfg.CreateMap<Task, TaskResponse>()
                .ForMember("Project",
                        opt => opt.MapFrom(p => Mapper.Map<Project, ProjectResponse>(p.Project)))
                     .ForMember("Status",
                        opt => opt.MapFrom(t => Mapper.Map<TaskStatus, TaskStatus>(t.Status)));
                // .ForMember("Tags", t => t.);
            });
        }
    }
}
