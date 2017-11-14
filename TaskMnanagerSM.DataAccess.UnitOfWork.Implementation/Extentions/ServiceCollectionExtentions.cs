using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace TaskManagerSM.DataAccess.UnitOfWork.Implementation.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection RegisterUnitOfWork(this IServiceCollection services, string connectionString)
        {
            services

                .AddDbContext<Db.TasksContext>(options => options.UseSqlServer(connectionString))
                .AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
