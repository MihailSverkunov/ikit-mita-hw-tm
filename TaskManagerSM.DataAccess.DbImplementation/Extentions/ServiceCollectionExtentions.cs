using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerSM.DataAccess.DbImplementation.Projects;
using TaskManagerSM.DataAccess.DbImplementation.Tasks;
using TaskManagerSM.DataAccess.Projects;
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

                .AddScoped<ITaskQuery, TaskQuery>()
                .AddScoped<ICreateTaskCommand, CreateTaskCommand>()

                ;
            return services;
        }
    }
}
