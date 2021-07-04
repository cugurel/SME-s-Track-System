using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class ServiceSituation
    {
        [Key]
        public int ServiceSiturationId { get; set; }
        public string SituationName { get; set; }
    }
}
