using FirmaSiparisApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisApp.Data.Concrete.EfCore
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }


        //veritabanı tablolarını temsil eden dbsetler
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-DUQOO3S;Initial Catalog=siparisApp;Integrated Security=SSPI;TrustServerCertificate=True;\"");
        //}


        
    }
}
