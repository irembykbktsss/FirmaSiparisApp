using FirmaSiparisApp.Entity;
using FirmaSiparisApp.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparisApp.Api.Controllers
{
    //localhost:5000/api/controller
    [ApiController]
    [Route("api/[controller]")]
    public class SiparisController : ControllerBase
    {
        //SiparisServis inject edildi
        private ISiparisServices _siparisService;

        private IFirmaServices _firmaService;



        public SiparisController(ISiparisServices siparisService, IFirmaServices firmaService)
        {
            _siparisService = siparisService;
            _firmaService = firmaService;
        }        

        [HttpGet]
        public async Task<IActionResult> GetSiparisler()
        {

            var siparis = await _siparisService.GetAll();
            return Ok(siparis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiparis(int id)
        {
            var siparis = await _siparisService.GetById(id);
            if (siparis == null)
            {
                return NotFound(); //404
            }
            return Ok(siparis);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSiparis(Siparis entity)
        {
            var firma = await _firmaService.GetById(entity.FirmaId);

            if (firma.OnayDurum == false)
            {
                return BadRequest("Firma Onaylı değil");
            }

            DateTime now = DateTime.Now;
            TimeSpan start = firma.siparisIzinBaslangicSaati; // 08:30
            TimeSpan end = firma.siparisIzinBitisSaati; // 11:00


            //firma siparis başlangıç ve bitiş saat izin aralıklarını kontrol eder
            if ((now.TimeOfDay >= start && now.TimeOfDay <= end))
            {
                await _siparisService.Creat(entity);
                return Ok("Firma siparişi oluşturuldu.");
            }
            else
            {
                return BadRequest("Firma siparis izin saatleri dışında sipariş almıyor.");

            }

        }
    }
}
