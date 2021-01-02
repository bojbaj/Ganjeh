using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Base;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAll();
        Task<ICollection<T>> GetList(int pageSize, int pageNumber, Func<T, bool> condition);
        Task<T> FindById(Guid Id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(Guid Id);
    }
}