using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerSM.DataAccess.DbImplementation.Projects;
using TaskManagerSM.DataAccess.DbImplementation.Tags;
using TaskManagerSM.DataAccess.DbImplementation.Tasks;
using TaskManagerSM.DataAccess.Projects;
using TaskManagerSM.DataAccess.Tags;
using TaskManagerSM.DataAccess.Tasks;

namespace TaskManagerSM.DataAccess.DbImplementation.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection RegisterQueriesAndCommands(this IServiceCollection services)
        {
            services.AddScoped<IProjectQuery, ProjectQuery>()
                .AddScoped<IProjectsListQuery, ProjectsListQuery>()
                .AddScoped<ICreateProjectCommand, CreateProjectCommand>()
                .AddScoped<IUpdateProjectCommand, UpdateProjectCommand>()
                .AddScoped<IDeleteProjectCommand, DeleteProjectCommand>()

                .AddScoped<ICreateTaskCommand, CreateTaskCommand>()
                .AddScoped<ITaskQuery, TaskQuery>()
                .AddScoped<ITasksListQuery, TasksListQuery>()
                .AddScoped<IUpdateTaskCommand, UpdateTaskCommand>()
                .AddScoped<IDeleteTaskCommand, DeleteTaskCommand>()
                .AddScoped<IAddTagToTaskCommand, AddTagToTaskCommand>()
                .AddScoped<IDeleteTagFromTaskCommand, DeleteTagFromTaskCommand>()

                .AddScoped<IDeleteTagCommand, DeleteTagCommand>()
                .AddScoped<ITagsListQuery, TagsListQuery>()

                ;
            return services;
        }
    }
}
