using MediaManager.Domains.Models;
using MediaManager.Domains.Services;
using MediaManager.EF.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MediaManager.EF.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DataModel
    {
        private readonly AppDbContextFactory _contextFactory;

        public GenericDataService(AppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                entity.ID = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.ID == id);
                context.Set<T>().Remove(entity);
                int changes = await context.SaveChangesAsync();
                return (changes >= 0);
            }
        }

        public async Task<T> Get(int id)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.ID == id);
                return entity;
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> query)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(query);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> query)
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().Where(query).ToListAsync();
                return entities;
            }
        }
    }
}
