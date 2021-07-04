using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class UploadSozlesmeModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DosyaAdi { get; set; }
        public string SozlesmeTuru { get; set; }
        public DateTime SozlesmeTarihi { get; set; }

        public string AnlasmaSekli { get; set; }

        [Required]
        public int KobiId { get; set; }

        [Required]
        public int SozlesmeSituationId { get; set; }

        [Required]
        public IFormFile Dosya { get; set; }
    }
}
