using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using FantasySky.CustomDF.Domain.Entities;

namespace FantasySky.CustomDF.Domain.Repositories;

public interface IReadOnlyRepository<TEntity> : IReadOnlyBasicRepository<TEntity>
    where TEntity : class, IEntity
{
    //IAsyncQueryableExecuter AsyncExecuter { get; }

    /// <summary>
    /// Gets a list of entities by the given <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">A condition to filter the entities</param>
    /// <param name="includeDetails">Set true to include details (sub-collections) of this entity</param>
    /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
    Task<List<TEntity>> GetListAsync(
        [NotNull] Expression<Func<TEntity, bool>> predicate,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);

    Task<IQueryable<TEntity>> GetQueryableAsync(CancellationToken cancellationToken);

    Task<IQueryable<TEntity>> WithDetailsAsync(CancellationToken cancellationToken);

    Task<IQueryable<TEntity>> WithDetailsAsync(CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] propertySelectors);
}

public interface IReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity>, IReadOnlyBasicRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
}
