using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class ServiceModel
    {
        public AnaHizmet AnaHizmet { get; set; }
        public AltHizmet AltHizmet { get; set; }
        public Kobi Kobi { get; set; }
        public KobiHizmet KobiHizmet { get; set; }
        public ServiceSituation ServiceSituation { get; set; }
    }
}
