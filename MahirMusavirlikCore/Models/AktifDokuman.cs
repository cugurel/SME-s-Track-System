using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class AktifDokuman
    {
        [Key]
        public int AktifDokumanId { get; set; }
        public string Aciklama { get; set; }
        public string Detay { get; set; }
        public DateTime IslemTarihi { get; set; }
        public DateTime GecerlilikTarihi { get; set; }
        
        [ForeignKey("Kobi")]
        public int KobiId { get; set; }
        public virtual Kobi Kobi { get; set; }
    }
}