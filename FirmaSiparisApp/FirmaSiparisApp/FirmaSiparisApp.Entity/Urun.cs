using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisApp.Entity
{
    public class Urun : BaseEntity
    {
      
        public int FirmaId { get; set; }
        public string? UrunAdi { get; set; }
        public int Stok { get; set; }

        public double Fiyat { get; set; }

        //bir ürün bir firmaya ait olabilir
        public Firma? Firma { get; set; }
    }
}
