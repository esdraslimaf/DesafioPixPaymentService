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


        public async Task<T> Add(T Entity)
        {
            try
            {
                _dbset.Add(Entity);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception)
            {
                throw;
            }
            return Entity;
        }
    }
}
