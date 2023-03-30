﻿using FirmaSiparisApp.Data.Abstract;
using FirmaSiparisApp.Entity;
using FirmaSiparisApp.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirmaSiparisApp.Service.Concrete
{
    public class SiparisManager : ISiparisServices
    {
        private ISiparisRepository _siparisRepository;

       

        //siparis repository ile bağlantı kurduk
        public SiparisManager(ISiparisRepository siparisRepository)
        {
            _siparisRepository = siparisRepository;
        }

      

        public async Task<Siparis> Creat(Siparis entity)
        {
            await _siparisRepository.Creat(entity);
            await _siparisRepository.SaveAsync();
            return entity;

        }

        public void Delete(Siparis entity)
        {
            //iş kuralları
            _siparisRepository.Delete(entity);
        }

        public async Task<List<Siparis>> GetAll()
        {
            return await _siparisRepository.GetAll();
        }

        public async Task<Siparis> GetById(int id)
        {
            return await _siparisRepository.GetById(id);
        }

        public void Update(Siparis entity)
        {
            _siparisRepository.Update(entity);
        }

        public bool Validation(Siparis entity)
        {
            throw new NotImplementedException();
        }

      

        public string ErrorMessage { get; set; }
    }
}
