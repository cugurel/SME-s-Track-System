using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class UploadKobiDosyaModel
    {
        [Required]
        public string DosyaAdi { get; set; }

        [Required]
        public IFormFile Dosya { get; set; }

        [Required]
        public int KobiId { get; set; }
    }
}
