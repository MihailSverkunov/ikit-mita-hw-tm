using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TaskManagerSM.DataAccess.UnitOfWork;
using TaskManagerSM.Entities;

namespace TaskManagerSM.DataAccess.UnitOfWork.Implementation
{
    public class EFQueryableRepository<TEntity, TContext> : EFRepository<TEntity, TContext>, IQueryableRepository<TEntity>,
        IAsyncEnumerableAccessor<TEntity>
        where TEntity : DomainObject 
        where TContext : DbContext
    {
        readonly DbSet<TEntity> set;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="context">Database context.</param>
        public EFQueryableRepository(TContext context) : base(context)
        {
            set = Context.Set<TEntity>();
        }

        /// <inheritdoc />
        public Type ElementType => typeof(TEntity);

        /// <inheritdoc />
        public Expression Expression => ((IQueryable<TEntity>)set).Expression;

        /// <inheritdoc />
        public IQueryProvider Provider => ((IQueryable<TEntity>)set).Provider;

        /// <inheritdoc />
        public IEnumerator<TEntity> GetEnumerator() => ((IQueryable<TEntity>)set).GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => ((IQueryable<TEntity>)set).GetEnumerator();

        /// <inheritdoc />
        public IAsyncEnumerable<TEntity> AsyncEnumerable => ((IAsyncEnumerableAccessor<TEntity>)set).AsyncEnumerable;
    }
}
