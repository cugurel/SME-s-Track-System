using MahirMusavirlikCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class SozlesmeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        Context c = new Context();
        public SozlesmeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            List<Sozlesme> sozlesmes = c.Sozlesmes.ToList();
            List<Kobi> kobis = c.Kobis.ToList();
            List<SozlesmeSituation> sozlesmeSituations = c.SozlesmeSituations.ToList();


            var employeeRecord = from e in sozlesmes
                                 join d in kobis on e.KobiId equals d.KobiId 
                                 join s in sozlesmeSituations on e.SozlesmeSituationId equals s.SozlesmeSituationId into table1
                                 from s in table1.ToList()
                                 select new ViewModel
                                 {
                                      sozlesmeSituation = s,
                                      sozlesme= e,
                                      kobi = d
                                 };
            return View(employeeRecord);
        }


        public IActionResult DosyaEkle()
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

            List<SelectListItem> value2 = (from x in c.SozlesmeSituations.ToList()

                                           select new SelectListItem
                                           {
                                               Text = x.SozlesmeSituationName,
                                               Value = x.SozlesmeSituationId.ToString()
                                           }).ToList();

            ViewBag.vl2 = value2;

            return View();
        }

        [HttpPost]
        public IActionResult UploadDocument(UploadSozlesmeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geçersiz veri");
            }

            var document = new Sozlesme
            {
                AnlasmaSekli = model.AnlasmaSekli,
                DosyaAdi = model.DosyaAdi,
                SozlesmeTarihi = model.SozlesmeTarihi,
                SozlesmeTuru = model.SozlesmeTuru,
                KobiId = model.KobiId,
                SozlesmeSituationId = model.SozlesmeSituationId,
                UniqueId = Guid.NewGuid().ToString()

            };

            document.UniqueId += Path.GetExtension(model.Dosya.FileName);
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Files");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, document.UniqueId);

            FileStream fs = new FileStream(path, FileMode.Create);
            model.Dosya.CopyTo(fs);
            fs.Close();

            c.Sozlesmes.Add(document);
            c.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult DeleteFile(string ui)
        {

            var document = c.Sozlesmes.FirstOrDefault(x => x.UniqueId == ui);
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Files", document.UniqueId);

            c.Sozlesmes.Remove(document);
            c.SaveChanges();

            System.IO.File.Delete(path);
            return Redirect("Index");
        }

        public IActionResult GetSozlesme(int id)
        {

            List<SelectListItem> value1 = (from c in c.Kobis.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.KobiUnvan,
                                               Value = c.KobiId.ToString()
                                           }).ToList();

            ViewBag.vl1 = value1;


            List<SelectListItem> value2 = (from x in c.SozlesmeSituations.ToList()

                                           select new SelectListItem
                                           {
                                               Text = x.SozlesmeSituationName,
                                               Value = x.SozlesmeSituationId.ToString()
                                           }).ToList();

            ViewBag.vl2 = value2;


            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            var value = c.Sozlesmes.Find(id);
            return View("GetSozlesme", value);
        }

        public IActionResult UpdateSozlesme(Sozlesme sozlesme)
        {
            List<SelectListItem> value1 = (from c in c.Kobis.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.KobiUnvan,
                                               Value = c.KobiId.ToString()
                                           }).ToList();

            ViewBag.vl1 = value1;


            List<SelectListItem> value2 = (from x in c.SozlesmeSituations.ToList()

                                           select new SelectListItem
                                           {
                                               Text = x.SozlesmeSituationName,
                                               Value = x.SozlesmeSituationId.ToString()
                                           }).ToList();

            ViewBag.vl2 = value2;

            var value = c.Sozlesmes.Find(sozlesme.Id);
            value.DosyaAdi = sozlesme.DosyaAdi;
            value.SozlesmeTuru = sozlesme.SozlesmeTuru;
            value.SozlesmeTarihi = sozlesme.SozlesmeTarihi;
            value.AnlasmaSekli = sozlesme.AnlasmaSekli;
            value.SozlesmeSituationId = sozlesme.SozlesmeSituationId;
            value.KobiId = sozlesme.KobiId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
