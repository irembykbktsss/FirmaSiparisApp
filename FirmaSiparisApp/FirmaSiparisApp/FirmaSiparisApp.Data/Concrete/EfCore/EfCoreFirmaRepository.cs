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
    public class EfCoreFirmaRepository : EfCoreGenericRepository<Firma>, IFirmaRepository
    {
        public EfCoreFirmaRepository(Context ctx) : base(ctx)
        {
        }

        private Context Context
        {
            get { return context as Context; }
        }
    }
}
