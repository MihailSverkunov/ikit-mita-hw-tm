using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagerSM.Entities;


namespace TaskManagerSM.DataAccess.UnitOfWork
{
    public interface IQueryableRepository<TEntity> : IRepository<TEntity>, IQueryable<TEntity>
        where TEntity : DomainObject
    {
    }
}
