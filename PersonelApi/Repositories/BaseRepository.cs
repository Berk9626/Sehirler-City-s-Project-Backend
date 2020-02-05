using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonelApi.Data;

namespace PersonelApi.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        PersonelContext _db;
        public BaseRepository(PersonelContext db)
        {
            _db = db;
        }
        public async  Task<bool> Comit()
        {
            return await _db.SaveChangesAsync() > 0;
            try
            {
               await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
        }

        public   void Entry(T entity)   
        {
            _db.Entry(entity).State = EntityState.Added;
             
        }

        public async Task<T> Find(int id)
        {
            return await Set().FindAsync(id);
        }

        public async Task<ICollection<T>> List()
        {
            return await Set().ToListAsync();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }
         
    }
}
