using AutoMapper;
using System;
using TaskManagerSM.Entities;
using TaskManagerSM.ViewModel.Projects;
using TaskManagerSM.ViewModel.Tags;
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
                //.ForMember("Tags", opt => be);
                //.ForMember("Tags", opt => opt.MapFrom(p => Mapper.Map<String[], TagsInTask>(p.Tags)));
                cfg.CreateMap<Task, TaskResponse>()
                    .ForMember("Project",
                        opt => opt.MapFrom(p => Mapper.Map<Project, ProjectResponse>(p.Project)))
                    .ForMember("Status",
                        opt => opt.MapFrom(t => Mapper.Map<TaskStatus, TaskStatus>(t.Status)));

                cfg.CreateMap<TagsInTask, String>().ConvertUsing(tit => tit.Tag.Name);

                cfg.CreateMap<String, TagsInTask>()
                    .ForMember("Tag", opt => opt.MapFrom(t => t));
                cfg.CreateMap<String, Tag>()
                   .ForMember("Name", opt => opt.MapFrom(t => t));

                cfg.CreateMap<UpdateTaskRequest, Task>()
                    .ForMember("Status", opt => opt.MapFrom(t => t.Status));
                

                //tags
                cfg.CreateMap<Tag, TagResponse>();

            });
        }
    }
}
