using ClosedXML.Excel;
using MahirMusavirlikCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Controllers
{
    [Authorize]
    public class AktifDokumanController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {

            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            var values = c.AktifDokumans.ToList();

            foreach (var item in values)
            {
                item.Kobi = c.Kobis.Find(item.KobiId);
            }
            
            return View(values.OrderBy(x=>x.GecerlilikTarihi).ToList());

        }
        [HttpGet]
        public IActionResult AddAktifDokuman()
        {
            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            List<SelectListItem> value1 = (from c in c.Kobis.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.KobiUnvan,
                                               Value = c.KobiId.ToString()
                                           }).ToList();

            ViewBag.vl1 = value1;
            return View();
        }

        [HttpPost]
        public IActionResult AddAktifDokuman(AktifDokuman ad)
        {
            List<SelectListItem> value1 = (from c in c.Kobis.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.KobiUnvan,
                                               Value = c.KobiId.ToString()
                                           }).ToList();

            ViewBag.vl1 = value1;

            c.AktifDokumans.Add(ad);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetDocument(int id)
        {
            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            List<SelectListItem> value1 = (from c in c.Kobis.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.KobiUnvan,
                                               Value = c.KobiId.ToString()
                                           }).ToList();

            ViewBag.vl1 = value1;

            var value = c.AktifDokumans.Find(id);
            return View("GetDocument", value);
        }

        public IActionResult UpdateDocument(AktifDokuman ad)
        {
             List<SelectListItem> value1 = (from c in c.Kobis.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.KobiUnvan,
                                               Value = c.KobiId.ToString()
                                           }).ToList();

            var value = c.AktifDokumans.Find(ad.AktifDokumanId);
            value.Aciklama = ad.Aciklama;
            value.Detay = ad.Detay;
            value.IslemTarihi = ad.IslemTarihi;
            value.GecerlilikTarihi = ad.GecerlilikTarihi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Function()
        {
            return Excel();
        }

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Aktif Dökümanlar");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Aciklama";
                worksheet.Cell(currentRow, 2).Value = "Detay";
                worksheet.Cell(currentRow, 3).Value = "IslemTarihi";
                worksheet.Cell(currentRow, 4).Value = "GecerlilikTarihi";



                var values = c.AktifDokumans.ToList();
                foreach (var item in values)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.Aciklama;
                    worksheet.Cell(currentRow, 2).Value = item.Detay;
                    worksheet.Cell(currentRow, 3).Value = item.IslemTarihi;
                    worksheet.Cell(currentRow, 4).Value = item.GecerlilikTarihi;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AktifDökümanListesi.xlsx");
                }
            }
        }

    }
}
