﻿using Microsoft.EntityFrameworkCore;
using MT.Shop.Application.Contracts;
using MT.Shop.Domain.Entities.BaseEntities;
using MT.Shop.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MT.Shop.Infrastructure.Helper;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int>
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return await Task.FromResult(entity);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(expression, cancellationToken);
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(cancellationToken);
    }

    public async Task Delete(T entity, CancellationToken cancellationToken)
    {
        var record = await GetByIdAsync(entity.Id, cancellationToken);
        record.SetDeleted();
        await UpdateAsync(entity);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return Task.FromResult(entity);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }
}