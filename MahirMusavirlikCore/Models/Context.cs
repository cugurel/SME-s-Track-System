using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server = 77.245.159.23\\MSSQLSERVER2019; database = mahirmusavir; user id=mahirmusavirmm; password=Xdjy64_1;");
            optionsBuilder.UseSqlServer("server = LAPTOP-6RP07O6C; database = mahirmusavir; integrated security=true;");
        }

        public DbSet<Kobi> Kobis { get; set; }
        public DbSet<Dosya> Dosyas { get; set; }
        public DbSet<AnaHizmet> AnaHizmets { get; set; }
        public DbSet<AltHizmet> AltHizmets { get; set; }
        public DbSet<KobiHizmet> KobiHizmets { get; set; }
        public DbSet<MatbuEvrak> MatbuEvraks { get; set; }
        public DbSet<ResmiEvrak> ResmiEvraks { get; set; }
        public DbSet<Sozlesme> Sozlesmes { get; set; }
        public DbSet<HizmetDetayDokuman> HizmetDetayDokumans { get; set; }
        public DbSet<AktifDokuman> AktifDokumans { get; set; }
        public DbSet<KobiOzelDosya> KobiOzelDosyas { get; set; }
        public DbSet<Situation> Situations { get; set; }
        public DbSet<ServiceSituation> ServiceSituations { get; set; }
        public DbSet<SozlesmeSituation> SozlesmeSituations { get; set; }
    }
}
