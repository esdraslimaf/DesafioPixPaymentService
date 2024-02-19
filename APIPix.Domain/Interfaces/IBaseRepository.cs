using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Add(T Entity);
        Task<T> GetById(Guid id);
        Task<ICollection<T>> GetAll();
        Task<T> Update(T Entity);
        Task<bool> Delete(Guid id);
    }
}
