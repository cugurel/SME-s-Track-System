using MahirMusavirlikCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MahirMusavirlikCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using ClosedXML.Excel;
using System.IO;

namespace MahirMusavirlikCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        Context c = new Context();
        public IActionResult Index()
        {
            ViewBag.countedKobis = c.Kobis.Where(x=>x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            var values = c.Kobis.OrderBy(x=>x.KobiKodu).ToList();

            foreach (var item in values)
            {
                item.Situation = c.Situations.Find(item.SituationId);
            }

            return View(values.ToList());
        }

        public IActionResult Function()
        {
            return Excel();
        }

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Kobiler");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "KobiUnvan";
                worksheet.Cell(currentRow, 2).Value = "KobiYetkili";
                worksheet.Cell(currentRow, 3).Value = "Telefon";



                var values = c.Kobis.ToList();
                foreach (var item in values)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.KobiUnvan;
                    worksheet.Cell(currentRow, 2).Value = item.KobiYetkili;
                    worksheet.Cell(currentRow, 3).Value = item.KobiPhone;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "KobiListesi.xlsx");
                }
            }
        }

    }
}
