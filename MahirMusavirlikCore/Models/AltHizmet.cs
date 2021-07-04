using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class AltHizmet
    {
        [Key]
        public int AltHizmetId { get; set; }
        public string AltHizmetAdi { get; set; }
    }
}
