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

       

        public SiparisController(ISiparisServices siparisService)
        {
            _siparisService = siparisService;
           
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
            
            await _siparisService.Creat(entity);
            return Ok("Sipariş oluşturuldu");

        }
    }
}
