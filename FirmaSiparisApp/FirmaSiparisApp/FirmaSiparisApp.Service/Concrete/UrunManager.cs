using FirmaSiparisApp.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirmaSiparisApp.Entity;
using FirmaSiparisApp.Data.Concrete.EfCore;
using FirmaSiparisApp.Data.Abstract;
using System.ComponentModel.DataAnnotations;

namespace FirmaSiparisApp.Service.Concrete
{
    public class UrunManager : IUrunServices
    {
        private IUrunRepository _urunRepository;

        //ürün repository ile bağlantı kurduk
        public UrunManager(IUrunRepository urunRepository) 
        {
            _urunRepository = urunRepository;   
        }

        public async Task<Urun> Creat(Urun entity)
        {
            //iş kuralları
            await _urunRepository.Creat(entity);
            await _urunRepository.SaveAsync();
            return entity;

        }

        public void Delete(Urun entity)
        {
            //iş kuralları
            _urunRepository.Delete(entity);
        }

        public async Task<List<Urun>> GetAll()
        {
            return await _urunRepository.GetAll();    
        }

        public async Task<Urun> GetById(int id)
        {
            return await _urunRepository.GetById(id);
        }

        public async Task Update(Urun entityToUpdate, Urun entity)
        {
            
            entityToUpdate.FirmaId = entity.FirmaId;
            entityToUpdate.UrunAdi = entity.UrunAdi;
            entityToUpdate.Stok = entity.Stok;
            entityToUpdate.Fiyat = entity.Fiyat;

            await _urunRepository.SaveAsync();

        }

        public bool Validation(Urun entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.UrunAdi))
            {
                ErrorMessage += "Ürün adı giriniz.\n";
                isValid = false;
            }

            if (entity.Fiyat < 0)
            {
                ErrorMessage += "Geçerli değer giriniz.\n";
                isValid = false;
            }

            return isValid;
        }

      

        public string ErrorMessage { get ; set ; }
    }
}
