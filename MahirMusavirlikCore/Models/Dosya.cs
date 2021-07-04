using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class Dosya
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DosyaAdi { get; set; }

        [ForeignKey("KobiHizmet")]
        public int KobiHizmetId { get; set; }

       
        public String UniqueId { get; set; }

        public KobiHizmet KobiHizmet   { get; set; }
    }

}
