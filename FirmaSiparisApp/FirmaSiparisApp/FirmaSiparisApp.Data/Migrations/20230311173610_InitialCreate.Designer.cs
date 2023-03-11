﻿// <auto-generated />
using System;
using FirmaSiparisApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirmaSiparisApp.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230311173610_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FirmaSiparisApp.Entity.Firma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirmaAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnayDurum")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("siparisIzinBaslangicSaati")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("siparisIzinBitisSaati")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Firmalar");
                });

            modelBuilder.Entity("FirmaSiparisApp.Entity.Siparis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FirmaId")
                        .HasColumnType("int");

                    b.Property<string>("MusteriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SiparisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirmaId");

                    b.HasIndex("UrunId");

                    b.ToTable("Siparisler");
                });

            modelBuilder.Entity("FirmaSiparisApp.Entity.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FirmaId")
                        .HasColumnType("int");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.Property<string>("UrunAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FirmaId");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("FirmaSiparisApp.Entity.Siparis", b =>
                {
                    b.HasOne("FirmaSiparisApp.Entity.Firma", "Firma")
                        .WithMany("Siparisler")
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirmaSiparisApp.Entity.Urun", "Urun")
                        .WithMany()
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Firma");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("FirmaSiparisApp.Entity.Urun", b =>
                {
                    b.HasOne("FirmaSiparisApp.Entity.Firma", "Firma")
                        .WithMany("Urunler")
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Firma");
                });

            modelBuilder.Entity("FirmaSiparisApp.Entity.Firma", b =>
                {
                    b.Navigation("Siparisler");

                    b.Navigation("Urunler");
                });
#pragma warning restore 612, 618
        }
    }
}
