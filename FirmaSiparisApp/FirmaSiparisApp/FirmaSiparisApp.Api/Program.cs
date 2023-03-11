using FirmaSiparisApp.Data.Abstract;
using FirmaSiparisApp.Data.Concrete.EfCore;
using FirmaSiparisApp.Service.Abstract;
using FirmaSiparisApp.Service.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FirmaSiparisApp.Api
{
    public class Program
    {
       

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

         

            builder.Services.AddDbContext<Context>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("MsSqlConnection")));

            //dependency injection
            builder.Services.AddScoped<IUrunRepository, EfCoreUrunRepository>();
            builder.Services.AddScoped<IFirmaRepository, EfCoreFirmaRepository>();
            builder.Services.AddScoped<ISiparisRepository, EfCoreSiparisRepository>();

            builder.Services.AddScoped<IUrunServices, UrunManager>();
            builder.Services.AddScoped<IFirmaServices, FirmaManager>();
            builder.Services.AddScoped<ISiparisServices, SiparisManager>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}