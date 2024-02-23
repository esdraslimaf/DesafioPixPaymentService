using APIPix.Data.Context;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private DbSet<T> _dbset;


        public BaseRepository(MyContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }


        public async Task<T> Add(T entity)
        {
            _dbset.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity != null)
            {
                _dbset.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
