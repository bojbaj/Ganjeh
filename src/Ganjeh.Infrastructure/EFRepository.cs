using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ganjeh.Domain.Base;
using Ganjeh.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Ganjeh.Infrastructure
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext appDbContext;
        private readonly HttpContext httpContext;

        public EFRepository(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.appDbContext = appDbContext;
            this.httpContext = httpContextAccessor.HttpContext;
        }

        private Guid CurrentUserId()
        {
            if (httpContext.User != null)
            {
                string IdValue = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                return Guid.Parse(IdValue);
            }
            return Guid.Empty;
        }

        public async Task<T> Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Created = DateTime.Now;
            entity.LastModified = DateTime.Now;
            entity.ModifiedBy = CurrentUserId();
            await appDbContext.Set<T>().AddAsync(entity);
            await appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid Id)
        {
            T entity = await appDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
            if (entity == null)
                throw new ArgumentNullException();

            appDbContext.Set<T>().Remove(entity);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<T> FindById(Guid Id)
        {
            return await appDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await appDbContext.Set<T>().AsNoTracking().OrderByDescending(x => x.Created).ToListAsync();
        }
        public Task<ICollection<T>> GetList(int pageSize, int pageNumber, Func<T, bool> condition)
        {
            List<T> list = appDbContext.Set<T>()
                .AsNoTracking()
                .Where(condition)
                .OrderByDescending(x => x.Created)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return Task.FromResult<ICollection<T>>(list);
        }
        public async Task<T> Update(T entity)
        {
            entity.LastModified = DateTime.Now;
            entity.ModifiedBy = CurrentUserId();
            appDbContext.Set<T>().Update(entity);
            await appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}