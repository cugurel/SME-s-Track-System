using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class Sozlesme
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DosyaAdi { get; set; }
        public string SozlesmeTuru { get; set; }
        public DateTime SozlesmeTarihi { get; set; }

        public string AnlasmaSekli { get; set; }

        [ForeignKey("Kobi")]
        public int KobiId { get; set; }

        public int SozlesmeSituationId { get; set; }
        public virtual SozlesmeSituation SozlesmeSituation { get; set; }

        public virtual Kobi Kobi { get; set; }
        public String UniqueId { get; set; }
    }
}
