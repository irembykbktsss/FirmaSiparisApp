using FirmaSiparisApp.Data.Abstract;
using FirmaSiparisApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisApp.Data.Concrete.EfCore
{
    public class EfCoreSiparisRepository : EfCoreGenericRepository<Siparis>, ISiparisRepository
    {
        public EfCoreSiparisRepository(Context ctx) : base(ctx)
        {
        }


        //Context'ten nesne oluşturduk(fonksiyonlarda kullanmak için)
        private Context Context
        {
            get { return context as Context; }
        }
    }
}
