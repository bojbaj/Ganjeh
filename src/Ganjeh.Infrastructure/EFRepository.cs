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

        public Task<ICollection<T>> GetList(Func<T, bool> condition = null, int pageSize = 0, int pageNumber = 0, string includes = null)
        {
            IQueryable<T> query = appDbContext.Set<T>()
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(includes))
            {
                foreach (string include in includes.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query
                    .Include(include);
                }
            }

            if (condition != null)
            {
                query = query
                .Where(condition)
                .AsQueryable();
            }

            query = query
                .OrderByDescending(x => x.Created);

            if (pageSize > 0)
            {
                query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            }
            List<T> list = query
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