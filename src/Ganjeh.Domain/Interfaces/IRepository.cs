using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Base;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetList(Func<T, bool> condition = null, int pageSize = 0, int pageNumber = 0);
        Task<T> FindById(Guid Id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(Guid Id);
    }
}