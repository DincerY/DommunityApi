using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Application.Repositories;
using Dommunity.Domain.Entities;
using Dommunity.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dommunity.Persistence.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly DommunityDbContext _context;

    public OrganizationRepository(DommunityDbContext context)
    {
        _context = context;
    }

    public DbSet<Organization> Table => _context.Set<Organization>();

    public IQueryable<Organization> GetAll()
    {
        return Table.AsQueryable();
    }

    public IQueryable<Organization> GetWhere(Expression<Func<Organization, bool>> method)
    {
        return Table.AsQueryable().Where(method);
    }

    public async Task<Organization> GetSingleAsync(Expression<Func<Organization, bool>> method)
    {
        return await Table.SingleOrDefaultAsync(method);
    }

    public async Task<Organization> GetByIdAsync(int id)
    {
        return await Table.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<bool> AddAsync(Organization model)
    {
        EntityEntry<Organization> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public bool Remove(Organization model)
    {
        EntityEntry<Organization> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool Update(Organization model)
    {
        EntityEntry<Organization> entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}