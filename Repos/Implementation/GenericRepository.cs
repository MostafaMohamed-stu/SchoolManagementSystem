using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Repos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Repos.Implementation
{
    public class GenericRepo<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext db;
        private readonly DbSet<T> dbset;

        public GenericRepo(AppDbContext db, DbSet<T> dbset)
        {
            this.db = db;
            this.dbset = dbset;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int ?id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await db.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            db.Set<T>().Update(entity);
            await SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
