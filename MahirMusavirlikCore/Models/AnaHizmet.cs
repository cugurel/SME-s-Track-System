using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class AnaHizmet
    {
        [Key]
        public int AnaHizmetId { get; set; }
        public string AnaHizmetAdi { get; set; }
    }
}
