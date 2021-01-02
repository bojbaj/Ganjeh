using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ganjeh.Domain.Base;
using Ganjeh.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ganjeh.Infrastructure
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext appDbContext;

        public EFRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<T> Add(T entity)
        {
            entity.Created = DateTime.Now;
            entity.LastModified = DateTime.Now;
            entity.ModifiedBy = Guid.Empty;
            await appDbContext.Set<T>().AddAsync(entity);
            await appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid Id)
        {
            T entity = await appDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
            if (entity == null)
                throw new ArgumentNullException();

            entity.Removed = true;
            await Update(entity);
            return true;
        }

        public async Task<T> FindById(Guid Id)
        {
            return await appDbContext.Set<T>().AsNoTracking().Where(x => !x.Removed).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await appDbContext.Set<T>().AsNoTracking().Where(x => !x.Removed).ToListAsync();
        }
        public Task<ICollection<T>> GetList(int pageSize, int pageNumber, Func<T, bool> condition)
        {
            List<T> list = appDbContext.Set<T>()
                .AsNoTracking()
                .Where(x => !x.Removed)
                .Where(condition)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return Task.FromResult<ICollection<T>>(list);
        }
        public async Task<T> Update(T entity)
        {
            entity.LastModified = DateTime.Now;
            entity.ModifiedBy = Guid.Empty;
            appDbContext.Set<T>().Update(entity);
            await appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}