using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class ResmiEvrak
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DosyaAdi { get; set; }
        public String UniqueId { get; set; }
    }
}
