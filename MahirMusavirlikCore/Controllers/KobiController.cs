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
    public class KobiController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
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

        [HttpGet]
        public ActionResult KobiAdd()
        {
            
            List<SelectListItem> value1 = (from c in c.Situations.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.SituationName,
                                               Value = c.SituationId.ToString()
                                           }).ToList();

            ViewBag.vl1 = value1;

            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();
            return View();
        }

        [HttpPost]
        public ActionResult KobiAdd(Kobi kobi)
        {
            List<SelectListItem> value1 = (from c in c.Situations.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.SituationName,
                                               Value = c.SituationId.ToString()
                                           }).ToList();

            ViewBag.vl1 = value1;

            c.Kobis.Add(kobi);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteKobi(int id)
        {
            var value = c.Kobis.Find(id);
            c.Kobis.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetKobi(int id)
        {
            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            List<SelectListItem> value1 = (from c in c.Situations.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.SituationName,
                                               Value = c.SituationId.ToString()
                                           }).ToList();

            
            ViewBag.vl1 = value1;

            var value = c.Kobis.Find(id);
            return View("GetKobi", value);
        }

        public ActionResult UpdateKobi(Kobi kobi)
        {
            var value = c.Kobis.Find(kobi.KobiId);
            value.KobiKodu = kobi.KobiKodu;
            value.KobiUnvan = kobi.KobiUnvan;
            value.KobiAddress = kobi.KobiAddress;
            value.KobiVergiNo = kobi.KobiVergiNo;
            value.KobiVergiDaire = kobi.KobiVergiDaire;
            value.KobiYetkili = kobi.KobiYetkili;
            value.KobiTcNo = kobi.KobiTcNo;
            value.KobiEDevletSifre = kobi.KobiEDevletSifre;
            value.KobiEİmzaSifre = kobi.KobiEİmzaSifre;
            value.KobiReferans = kobi.KobiReferans;
            value.KobiMaliMusaviri = kobi.KobiMaliMusaviri;
            value.SituationId = kobi.SituationId;
            value.KobiPhone = kobi.KobiPhone;
            value.KobiMail = kobi.KobiMail;
            value.KobiPassword = kobi.KobiPassword;
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
