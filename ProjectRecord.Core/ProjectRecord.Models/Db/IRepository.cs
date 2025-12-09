using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ProjectRecord.Models.Db;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    EfDataContext DbContext { get; }

    public DbSet<TEntity> DbSet { get; }
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

    ValueTask<EntityEntry<TEntity>> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default(CancellationToken));
}