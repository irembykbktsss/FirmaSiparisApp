using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirmaSiparisApp.Entity;

namespace FirmaSiparisApp.Service.Abstract
{
    public interface IUrunServices : IValidator<Urun>
    {
        Task<Urun> GetById(int id);

        Task<List<Urun>> GetAll();

        Task<Urun> Creat(Urun entity);

        Task Update(Urun entityToUpdate ,Urun entity);

        void Delete(Urun entity);
    }
}
