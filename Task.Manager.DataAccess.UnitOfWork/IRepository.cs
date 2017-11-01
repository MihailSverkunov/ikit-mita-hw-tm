using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using TaskManagerSM.Entities;


namespace TaskManagerSM.DataAccess.UnitOfWork
{
    public interface IRepository<TEntity> where TEntity : DomainObject
    {
        void Add(TEntity entity);
        Task<TEntity> FindAsync(int id);
    }
}
