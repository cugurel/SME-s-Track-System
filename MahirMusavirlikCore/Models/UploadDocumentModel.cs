﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class UploadDocumentModel
    {
        [Required]
        public string DosyaAdi { get; set; }

        [Required]
        public IFormFile Dosya { get; set; }

        [Required]
        public int KobiHizmetId { get; set; }
    }
}
