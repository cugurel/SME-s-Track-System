using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class KobiHizmet
    {
        [Key]
        public int KobiHizmetId { get; set; }
        public int AnaHizmetId { get; set; }

        public virtual AnaHizmet AnaHizmet { get; set; }
        public int AltHizmetId { get; set; }

        public virtual AltHizmet AltHizmet { get; set; }
        public string DosyaAdi { get; set; }
        public int KobiId { get; set; }
        public virtual Kobi Kobi { get; set; }

        public int ServiceSituationId { get; set; }
        public virtual ServiceSituation ServiceSituation { get; set; }
        public string DosyaDurumu { get; set; }
        public string AnlasmaSekli { get; set; }
    }
}
