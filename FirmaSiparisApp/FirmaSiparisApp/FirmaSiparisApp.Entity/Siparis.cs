using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisApp.Entity
{
    public class Siparis : BaseEntity
    {
       
        public int FirmaId { get; set; }

        public int UrunId { get; set; }

        public string MusteriAdi { get; set; }
        public DateTime SiparisTarihi { get; set; }

        //bir siparis bir firmaya ait olabilir
        public Firma? Firma { get; set; }

        //bir siparis bir ürüne ait olabilir
        public Urun? Urun { get; set; }
    }
}
