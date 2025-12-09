using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ProjectRecord.Models.Db;

public abstract class RepositoryBase<TEntity> where TEntity : BaseEntity
{
    public RepositoryBase()
    {
    }

    public RepositoryBase(EfDataContext dbContext)
    {
        this.DefaultDbContext = dbContext ?? throw new Exception("dbContext未实例化。");
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return EFContext.SaveChangesAsync(cancellationToken);
    }

    public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        return EFContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public ValueTask<EntityEntry<TEntity>> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        return this.DbSet.AddAsync(entity, cancellationToken);
    }

    private EfDataContext DefaultDbContext { get; set; }

    private EfDataContext EFContext
    {
        get
        {
            return DefaultDbContext;
        }
    }

    public virtual EfDataContext DbContext
    {
        get { return DefaultDbContext; }
    }

    public DbSet<TEntity> DbSet
    {
        get { return EFContext.Set<TEntity>(); }
    }
}