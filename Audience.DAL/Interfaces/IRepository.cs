using Audience.DAL.Entities;
using Audience.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Create(T item);
        Task<bool> Delete(int id);
        Task<T> FirstOrDefaultAsync(T model);
    }
}
