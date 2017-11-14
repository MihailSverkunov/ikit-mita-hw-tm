using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerSM.DataAccess.DbImplementation.Projects;
using TaskManagerSM.DataAccess.Projects;

namespace TaskManagerSM.DataAccess.DbImplementation.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection RegisterUnitOfWorkQueriesAndCommands(this IServiceCollection services)
        {
            services.AddScoped<IProjectQuery, ProjectQuery>()
                .AddScoped<IProjectsListQuery, ProjectsListQuery>()
                .AddScoped<ICreateProjectCommand, CreateProjectCommand>();
            return services;
        }
    }
}
