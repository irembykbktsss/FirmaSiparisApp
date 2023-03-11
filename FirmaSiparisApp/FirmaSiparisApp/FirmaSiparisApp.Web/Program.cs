using FirmaSiparisApp.Data.Abstract;
using FirmaSiparisApp.Data.Concrete.EfCore;
using FirmaSiparisApp.Service.Abstract;
using FirmaSiparisApp.Service.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;




namespace FirmaSiparisApp.Web
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                builder.Configuration.GetConnectionString("MsSqlConnection")));

            //dependency injection
            builder.Services.AddScoped<IUrunRepository, EfCoreUrunRepository>();
            builder.Services.AddScoped<IFirmaRepository, EfCoreFirmaRepository>();
            builder.Services.AddScoped<ISiparisRepository, EfCoreSiparisRepository>();

            builder.Services.AddScoped<IUrunServices, UrunManager>();
            builder.Services.AddScoped<IFirmaServices, FirmaManager>();
            builder.Services.AddScoped<ISiparisServices, SiparisManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}