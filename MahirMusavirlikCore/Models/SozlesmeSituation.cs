using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class SozlesmeSituation
    {
        [Key]
        public int SozlesmeSituationId { get; set; }
        public string SozlesmeSituationName { get; set; }
    }
}
