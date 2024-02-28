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

public class CommunityRepository : ICommunityRepository
{
    private readonly DommunityDbContext _context;

    public CommunityRepository(DommunityDbContext context)
    {
        _context = context;
    }

    public DbSet<Community> Table => _context.Set<Community>();
    public IQueryable<Community> GetAll()
    {
        return Table.AsQueryable();
    }

    public IQueryable<Community> GetWhere(Expression<Func<Community, bool>> method)
    {
        return Table.AsQueryable().Where(method);
    }

    public async Task<Community> GetSingleAsync(Expression<Func<Community, bool>> method)
    {
        return await Table.SingleOrDefaultAsync(method);
    }

    public async Task<Community> GetByIdAsync(int id)
    {
        return await Table.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<bool> AddAsync(Community model)
    {
        EntityEntry<Community> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public bool Remove(Community model)
    {
        EntityEntry<Community> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool Update(Community model)
    {
        EntityEntry<Community> entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}