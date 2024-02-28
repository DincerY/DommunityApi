using System.Linq.Expressions;
using Dommunity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dommunity.Application.Repositories;

public interface IOrganizationRepository
{
    DbSet<Organization> Table { get; }
    IQueryable<Organization> GetAll();
    IQueryable<Organization> GetWhere(Expression<Func<Organization, bool>> method);
    Task<Organization> GetSingleAsync(Expression<Func<Organization, bool>> method);
    Task<Organization> GetByIdAsync(int id);
    Task<bool> AddAsync(Organization model);
    bool Remove(Organization model);
    bool Update(Organization model);
    Task<int> SaveAsync();

}