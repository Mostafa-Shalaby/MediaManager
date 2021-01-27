using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MediaManager.Domains.Services
{
    public interface IDataService<T>
    {
        Task<T> Create();

        Task<T> Update();

        Task<bool> Delete();

        Task<T> Get(int id);

        Task<T> Get(Expression<Func<T, bool>> query);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> query);
    }
}
