using Dommunity.Domain.Entities;
using Dommunity.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dommunity.Application.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    DbSet<TEntity> Table { get; }
    IQueryable<TEntity> GetAll(bool changeTracking = true);
    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method);
    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method);
    Task<TEntity> GetByIdAsync(int id);
    Task<bool> AddAsync(TEntity model);
    bool Remove(TEntity model);
    bool Update(TEntity model);
    Task<int> SaveAsync();
}