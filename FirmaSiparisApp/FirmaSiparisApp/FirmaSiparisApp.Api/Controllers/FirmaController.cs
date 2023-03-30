using FirmaSiparisApp.Entity;
using FirmaSiparisApp.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparisApp.Api.Controllers
{
    //localhost:5000/api/controller
    [ApiController]
    [Route("api/[controller]")]

    public class FirmaController : ControllerBase
    {

        //FirmaServis inject edildi
        private IFirmaServices _firmaService;
        public FirmaController(IFirmaServices firmaService)
        {
            _firmaService = firmaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFirmalar()
        {

            var firmalar = await _firmaService.GetAll();
            return Ok(firmalar);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFirma(int id)
        {
            var firma = await _firmaService.GetById(id);
            if (firma == null)
            {
                return NotFound(); //404
            }
            return Ok(firma);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFirma(Firma entity)
        {
            await _firmaService.Creat(entity);
            return Ok(entity);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFirma(int id, Firma entity)
        {
           //gönderilen id ile güncellemek istediğimiz id eşit mi
           if(id!=entity.Id)
            {
                return BadRequest();
            }

           //veritabanında id bilgisini kontrol ediyoruz
            var firma = await _firmaService.GetById(id);

            if(firma == null)
            {
                return NotFound();
            }

            await _firmaService.Update(firma,entity);
            return Ok(entity);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirma(int id)
        {
           
            //veritabanında id bilgisini kontrol ediyoruz
            var firma = await _firmaService.GetById(id);

            if (firma == null)
            {
                return NotFound();
            }

            await _firmaService.Delete(firma);
            return Ok();

        }


    }
}
