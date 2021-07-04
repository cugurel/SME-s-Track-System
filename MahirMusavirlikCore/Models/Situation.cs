using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class Situation
    {
        [Key]
        public int SituationId { get; set; }
        public string SituationName { get; set; }
        public ICollection<Kobi> Kobis { get; set; }
    }
}
