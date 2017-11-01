using System.Threading.Tasks;
using TaskManagerSM.Entities;

namespace TaskManagerSM.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IQueryableRepository<Project> Projects { get; }

        void Migrate();

        int Commit();

        Task<int> CommitAsync();
    }
}
