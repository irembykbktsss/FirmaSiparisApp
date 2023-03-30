using System;
using FirmaSiparisApp.Entity;
using FirmaSiparisApp.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace FirmaSiparisApp.Api.Controllers
{
    //localhost:5000/api/controller
    [ApiController]
    [Route("api/[controller]")]
    public class UrunController : ControllerBase
    {
        //UrunServis inject edildi
        private IUrunServices _urunService;
        public UrunController(IUrunServices urunService)
        {
            _urunService = urunService;
        }

        [HttpGet]   
        public async Task<IActionResult> GetUrunler() 
        {

            var urunler = await _urunService.GetAll();
            return Ok(urunler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUrun(int id)
        {
            var urun = await _urunService.GetById(id);
            if (urun==null)
            {
                return NotFound(); //404
            }
            return Ok(urun);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUrun(Urun entity)
        {
            await _urunService.Creat(entity);
            return Ok(entity); //200 oluşan entity bilgisi döner 
        }
    }
}
