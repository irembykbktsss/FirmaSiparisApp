using FirmaSiparisApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisApp.Service.Abstract
{
    public interface IFirmaServices : IValidator<Firma>
    {
        Task<Firma> GetById(int id);

        Task<List<Firma>> GetAll();

        Task<Firma> Creat(Firma entity);

        Task Update(Firma entityToUpdate, Firma entity);

        Task Delete(Firma entity);
    }
}
