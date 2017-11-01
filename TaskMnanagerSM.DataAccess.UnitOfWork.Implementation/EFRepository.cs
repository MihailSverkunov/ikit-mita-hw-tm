using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.UnitOfWork;
using TaskManagerSM.Entities;

namespace TaskManagerSM.DataAccess.UnitOfWork.Implementation
{
    public class EFRepository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : DomainObject 
        where TContext : DbContext
    {
        private DbSet<TEntity> DbSet { get;}

        protected TContext Context { get; }

        public EFRepository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }


    }
}
