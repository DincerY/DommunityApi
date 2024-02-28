using Dommunity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dommunity.Application.Repositories;

public interface ICommunityRepository
{
    DbSet<Community> Table { get; }
    IQueryable<Community> GetAll();
    IQueryable<Community> GetWhere(Expression<Func<Community, bool>> method);
    Task<Community> GetSingleAsync(Expression<Func<Community, bool>> method);
    Task<Community> GetByIdAsync(int id);
    Task<bool> AddAsync(Community model);
    bool Remove(Community model);
    bool Update(Community model);
    Task<int> SaveAsync();
}