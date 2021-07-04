﻿// <auto-generated />
using MahirMusavirlikCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MahirMusavirlikCore.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210524183851_v4")]
    partial class v4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MahirMusavirlikCore.Models.AltHizmet", b =>
                {
                    b.Property<int>("AltHizmetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AltHizmetAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AltHizmetId");

                    b.ToTable("AltHizmets");
                });

            modelBuilder.Entity("MahirMusavirlikCore.Models.AnaHizmet", b =>
                {
                    b.Property<int>("AnaHizmetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnaHizmetAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnaHizmetId");

                    b.ToTable("AnaHizmets");
                });

            modelBuilder.Entity("MahirMusavirlikCore.Models.Dosya", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnlasmaSekli")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DosyaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DosyaDurumu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KobiHizmetId")
                        .HasColumnType("int");

                    b.Property<string>("UniqueId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KobiHizmetId");

                    b.ToTable("Dosyas");
                });

            modelBuilder.Entity("MahirMusavirlikCore.Models.Kobi", b =>
                {
                    b.Property<int>("KobiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KobiAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KobiEDevletSifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KobiEİmzaSifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KobiKodu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KobiMaliMusaviri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KobiReferans")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KobiTcNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KobiUnvan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KobiVergiDaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KobiVergiNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KobiYetkili")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KobiId");

                    b.ToTable("Kobis");
                });

            modelBuilder.Entity("MahirMusavirlikCore.Models.KobiHizmet", b =>
                {
                    b.Property<int>("KobiHizmetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AltHizmetId")
                        .HasColumnType("int");

                    b.Property<int>("AnaHizmetId")
                        .HasColumnType("int");

                    b.Property<string>("DosyaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KobiId")
                        .HasColumnType("int");

                    b.HasKey("KobiHizmetId");

                    b.HasIndex("AltHizmetId");

                    b.HasIndex("AnaHizmetId");

                    b.HasIndex("KobiId");

                    b.ToTable("KobiHizmets");
                });

            modelBuilder.Entity("MahirMusavirlikCore.Models.MatbuEvrak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DosyaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MatbuEvraks");
                });

            modelBuilder.Entity("MahirMusavirlikCore.Models.ResmiEvrak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DosyaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ResmiEvraks");
                });

            modelBuilder.Entity("MahirMusavirlikCore.Models.Dosya", b =>
                {
                    b.HasOne("MahirMusavirlikCore.Models.KobiHizmet", "KobiHizmet")
                        .WithMany()
                        .HasForeignKey("KobiHizmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KobiHizmet");
                });

            modelBuilder.Entity("MahirMusavirlikCore.Models.KobiHizmet", b =>
                {
                    b.HasOne("MahirMusavirlikCore.Models.AltHizmet", "AltHizmet")
                        .WithMany()
                        .HasForeignKey("AltHizmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MahirMusavirlikCore.Models.AnaHizmet", "AnaHizmet")
                        .WithMany()
                        .HasForeignKey("AnaHizmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MahirMusavirlikCore.Models.Kobi", "Kobi")
                        .WithMany("KobiHizmets")
                        .HasForeignKey("KobiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AltHizmet");

                    b.Navigation("AnaHizmet");

                    b.Navigation("Kobi");
                });

            modelBuilder.Entity("MahirMusavirlikCore.Models.Kobi", b =>
                {
                    b.Navigation("KobiHizmets");
                });
#pragma warning restore 612, 618
        }
    }
}
