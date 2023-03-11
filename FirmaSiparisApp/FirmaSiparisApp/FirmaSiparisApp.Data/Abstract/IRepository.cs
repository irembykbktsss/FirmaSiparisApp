using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisApp.Data.Abstract
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);

        Task<List<T>> GetAll();

        Task Creat(T entity);

        Task Update(T entity);

        void Delete(T entity);

        void Save();
        Task<int> SaveAsync();

    }
}
