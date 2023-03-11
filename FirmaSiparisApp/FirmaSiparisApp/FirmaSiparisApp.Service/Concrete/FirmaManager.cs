using FirmaSiparisApp.Data.Abstract;
using FirmaSiparisApp.Entity;
using FirmaSiparisApp.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisApp.Service.Concrete
{
    public class FirmaManager : IFirmaServices
    {
        private IFirmaRepository _firmaRepository;

        //firma repository ile bağlantı kurduk
        public FirmaManager(IFirmaRepository firmaRepository)
        {
            _firmaRepository = firmaRepository;
        }

        public async Task<Firma> Creat(Firma entity)
        {
            
            //iş kuralları
            await _firmaRepository.Creat(entity);
            await _firmaRepository.SaveAsync();
            return entity;

        }

        public void Delete(Firma entity)
        {
            //iş kuralları
            _firmaRepository.Delete(entity);
        }

        public async Task<List<Firma>> GetAll()
        {
            return await _firmaRepository.GetAll();
        }

        public async Task<Firma> GetById(int id)
        {
            return await _firmaRepository.GetById(id);
        }

        //firma onay durum, siparişİzinBaşlangıç ve Bitiş saatlerini güncelleme
        public async Task Update(Firma entityToUpdate, Firma entity)
        {
            entityToUpdate.OnayDurum = entity.OnayDurum;
            entityToUpdate.siparisIzinBaslangicSaati = entity.siparisIzinBaslangicSaati;
            entityToUpdate.siparisIzinBitisSaati = entity.siparisIzinBitisSaati;
           
            await _firmaRepository.SaveAsync();

        }

        public bool Validation(Firma entity)
        {
            throw new NotImplementedException();
        }

        public string ErrorMessage { get; set; }
    }
}
