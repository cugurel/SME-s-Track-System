using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class Kobi
    {
        [Key]
        public int KobiId { get; set; }
        public string KobiKodu { get; set; }
        public string KobiUnvan { get; set; }
        public string KobiAddress { get; set; }
        public string KobiVergiNo { get; set; }
        public string KobiVergiDaire { get; set; }
        public string KobiYetkili { get; set; }
        public string KobiTcNo { get; set; }
        public string KobiEDevletSifre { get; set; }
        public string KobiEİmzaSifre { get; set; }
        public string KobiReferans { get; set; }
        public string KobiMaliMusaviri { get; set; }
        public string KobiPhone { get; set; }
        public string KobiPer { get; set; }
        public string KobiMail { get; set; }
        public string KobiPassword { get; set; }

        public int SituationId { get; set; }
        public virtual Situation Situation { get; set; }

        public ICollection<KobiHizmet> KobiHizmets { get; set; }
        public ICollection<AktifDokuman> AktifDokumans { get; set; }
    }
}
