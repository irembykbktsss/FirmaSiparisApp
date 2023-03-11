using FirmaSiparisApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisApp.Service.Abstract
{
    public interface ISiparisServices : IValidator<Siparis>
    {
        Task<Siparis> GetById(int id);

        Task<List<Siparis>> GetAll();

        Task<Siparis> Creat(Siparis entity);

        void Update(Siparis entity);

        void Delete(Siparis entity);
    }
}
