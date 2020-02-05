using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelApi.Repositories
{
    interface IBaseRepository<T> where T : class, new()

    {
        void Update(T entity);
        void Delete(T entity);
        void Entry(T entity);
        Task<bool> Comit();
        Task<ICollection<T>> List();
        Task<T> Find(int id);
        DbSet<T> Set();

    }
}
