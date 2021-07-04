using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Models
{
    public class KobilerveHizmetler
    {
        public IEnumerable<Kobi> Kobiler { get; set; }
        public IEnumerable<KobiHizmet> KobiHizmetler { get; set; }
        public IEnumerable<AnaHizmet> AnaHizmets { get; set; }
        public IEnumerable<AltHizmet> AltHizmets { get; set; }
        public IEnumerable<KobiOzelDosya> KobiOzelDosyas { get; set; }
        public IEnumerable<ServiceSituation> ServiceSituations { get; set; }
    }
}