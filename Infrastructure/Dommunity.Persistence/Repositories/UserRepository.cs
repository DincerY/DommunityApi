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

public class UserRepository : IUserRepository
{
    private readonly DommunityDbContext _context;

    public UserRepository(DommunityDbContext context)
    {
        _context = context;
    }

    public DbSet<User> Table => _context.Set<User>();
    public IQueryable<User> GetAll(bool changeTracking = true)
    {
        var queryable = Table.AsQueryable();
        if (!changeTracking)
        {
            queryable.AsNoTracking();
        }
        return queryable;
    }

    public IQueryable<User> GetWhere(Expression<Func<User, bool>> method)
    {
        return Table.AsQueryable().Where(method);
    }

    public async Task<User> GetSingleAsync(Expression<Func<User, bool>> method)
    {
        return await Table.SingleOrDefaultAsync(method);
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await Table.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> AddAsync(User model)
    {
        EntityEntry<User> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public bool Remove(User model)
    {
        EntityEntry<User> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool Update(User model)
    {
        EntityEntry<User> entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}