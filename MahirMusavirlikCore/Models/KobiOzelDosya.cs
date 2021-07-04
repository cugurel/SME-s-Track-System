using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class KobiOzelDosya
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public string DosyaAdi { get; set; }

        [ForeignKey("Kobi")]
        public int KobiId { get; set; }


        public String UniqueId { get; set; }

        public Kobi Kobi { get; set; }
    }
}

