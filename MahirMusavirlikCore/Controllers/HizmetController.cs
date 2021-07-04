using ClosedXML.Excel;
using MahirMusavirlikCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Controllers
{
    public class HizmetController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {

            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            List<AltHizmet> altHizmets = c.AltHizmets.ToList();
            List<AnaHizmet> anaHizmets = c.AnaHizmets.ToList();
            List<Kobi> kobis = c.Kobis.ToList();
            List<KobiHizmet> kobiHizmets = c.KobiHizmets.ToList();
            List<ServiceSituation> serviceSituations = c.ServiceSituations.ToList();


            var serviceRecord = from k in kobiHizmets
                                 join a in anaHizmets on k.AnaHizmetId equals a.AnaHizmetId
                                 join l in altHizmets on k.AltHizmetId equals l.AltHizmetId
                                 join b in kobis on k.KobiId equals b.KobiId
                                 join r in serviceSituations on k.ServiceSituationId equals r.ServiceSiturationId
           
                                 select new ServiceModel
                                 {
                                     KobiHizmet = k,
                                     AnaHizmet = a,
                                     AltHizmet = l,
                                     Kobi = b,
                                     ServiceSituation = r
                                 };
            return View(serviceRecord);
        }

        public IActionResult Function()
        {
            return Excel();
        }

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Hizmet Listesi");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Ana Hizmet";
                worksheet.Cell(currentRow, 2).Value = "Alt Hizmet";
                worksheet.Cell(currentRow, 3).Value = "Dosya Adı";
                worksheet.Cell(currentRow, 4).Value = "Kobi Unvanı";
                worksheet.Cell(currentRow, 5).Value = "Hizmet Durumu";

                List<AltHizmet> altHizmets = c.AltHizmets.ToList();
                List<AnaHizmet> anaHizmets = c.AnaHizmets.ToList();
                List<Kobi> kobis = c.Kobis.ToList();
                List<KobiHizmet> kobiHizmets = c.KobiHizmets.ToList();
                List<ServiceSituation> serviceSituations = c.ServiceSituations.ToList();


                var serviceRecord = from k in kobiHizmets
                                    join a in anaHizmets on k.AnaHizmetId equals a.AnaHizmetId
                                    join l in altHizmets on k.AltHizmetId equals l.AltHizmetId
                                    join b in kobis on k.KobiId equals b.KobiId
                                    join r in serviceSituations on k.ServiceSituationId equals r.ServiceSiturationId

                                    select new ServiceModel
                                    {
                                        KobiHizmet = k,
                                        AnaHizmet = a,
                                        AltHizmet = l,
                                        Kobi = b,
                                        ServiceSituation = r
                                    };


                var values = serviceRecord.ToList();
                foreach (var item in values)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.AnaHizmet.AnaHizmetAdi;
                    worksheet.Cell(currentRow, 2).Value = item.AltHizmet.AltHizmetAdi;
                    worksheet.Cell(currentRow, 3).Value = item.KobiHizmet.DosyaAdi;
                    worksheet.Cell(currentRow, 4).Value = item.Kobi.KobiUnvan;
                    worksheet.Cell(currentRow, 5).Value = item.ServiceSituation.SituationName;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "HizmetListesi.xlsx");
                }
            }
        }
    }
}
