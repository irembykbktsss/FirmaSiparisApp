namespace FirmaSiparisApp.Entity
{
    public class Firma : BaseEntity
    {
        
        public string FirmaAdi { get; set; }

        public bool OnayDurum { get; set; }
        public TimeSpan siparisIzinBaslangicSaati { get; set; }

        public TimeSpan siparisIzinBitisSaati { get; set; }

        //bir firmanın birden fazla ürünü olabilir
        public List<Urun> Urunler { get; set; }

        //bir firmanın birden fazla siparisi olabilir
        public List<Siparis> Siparisler { get; set; }
    }
}