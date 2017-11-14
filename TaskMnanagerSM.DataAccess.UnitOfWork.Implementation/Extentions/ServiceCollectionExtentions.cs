using Microsoft.Extensions.DependencyInjection;


namespace TaskManagerSM.DataAccess.UnitOfWork.Implementation.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection RegisterUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
