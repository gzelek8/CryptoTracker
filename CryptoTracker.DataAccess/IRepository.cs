using CryptoTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);


    }
}
