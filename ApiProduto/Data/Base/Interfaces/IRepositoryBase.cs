using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
