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
    public class EfCoreUrunRepository : EfCoreGenericRepository<Urun>, IUrunRepository
    {
        public EfCoreUrunRepository(Context context) : base(context)
        {
        }

        private Context Context
        {
            get { return context as Context;  }
        }


        
    }
}
