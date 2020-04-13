using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dab_aflevering_2.Contracts;

namespace Dab_aflevering_2.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

    }
}