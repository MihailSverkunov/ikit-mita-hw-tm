using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.UnitOfWork;
using TaskManagerSM.Db;
using TaskManagerSM.Entities;

namespace TaskManagerSM.DataAccess.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private TasksContext Context { get; }

        private readonly IQueryableRepository<Project> _projects;
        public IQueryableRepository<Project> Projects => _projects;

        public UnitOfWork(TasksContext context)
        {
            Context = context;
            _projects = new EFQueryableRepository<Project, TasksContext>(Context);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Migrate()
        {
            Context.Database.Migrate();
        }
    }
}
