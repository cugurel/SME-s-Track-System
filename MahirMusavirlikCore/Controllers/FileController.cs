using MahirMusavirlikCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Controllers
{
    [Authorize]
    public class FileController : Controller
    {

        Context c = new Context();
        
        private readonly IHostingEnvironment _hostingEnvironment;
        public FileController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index(int id)
        {
            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            ViewBag.HizId = id;
            var values = c.Dosyas.Where(x => x.KobiHizmetId == id).ToList();
            return View(values);
        }

        public IActionResult DeleteFile(string ui)
        {

            var document = c.Dosyas.FirstOrDefault(x => x.UniqueId == ui);
            int kobiId = document.KobiHizmetId;
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Files", document.UniqueId);

            c.Dosyas.Remove(document);
            c.SaveChanges();

            System.IO.File.Delete(path);
            return Redirect($"Index/{kobiId}");
        }


        [HttpGet]
        public ActionResult DosyaEkle(int id)
        {
            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult UploadDocument(UploadDocumentModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geçersiz veri");
            }

            var document = new Dosya
            {
                DosyaAdi = model.DosyaAdi,
                KobiHizmetId = model.KobiHizmetId,
                UniqueId = Guid.NewGuid().ToString()
                     

            };

            document.UniqueId += Path.GetExtension(model.Dosya.FileName);
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Files");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            int kobiId = model.KobiHizmetId;

            path = Path.Combine(path, document.UniqueId);

            FileStream fs = new FileStream(path, FileMode.Create);
            model.Dosya.CopyTo(fs);
            fs.Close();

            c.Dosyas.Add(document);
            c.SaveChanges();

            return Redirect($"Index/{kobiId}");
        }

        [HttpGet]
        public IActionResult GetFileDetail(int id)
        {
            var value = c.Dosyas.FirstOrDefault(x => x.Id == id);
            return View("GetFileDetail", value);
        }

        public IActionResult EditService(int id)
        {

            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            List<SelectListItem> value1 = (from c in c.AnaHizmets.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.AnaHizmetAdi,
                                               Value = c.AnaHizmetId.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from c in c.AltHizmets.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.AltHizmetAdi,
                                               Value = c.AltHizmetId.ToString()
                                           }).ToList();

            List<SelectListItem> value4 = (from c in c.ServiceSituations.ToList()

                                           select new SelectListItem
                                           {
                                               Text = c.SituationName,
                                               Value = c.ServiceSiturationId.ToString()
                                           }).ToList();


            ViewBag.vl1 = value1;

            ViewBag.vl4 = value4;

            ViewBag.vl2 = value2;

            var KobiId = c.KobiHizmets.Where(x => x.KobiHizmetId == id).Select(x => x.KobiId).FirstOrDefault();
            ViewBag.KobiId = KobiId;

            var value = c.KobiHizmets.Find(id);
            return View("EditService",value);
        }

        [HttpPost]
        public IActionResult UpdateService(KobiHizmet kbh)
        {
            var KobiId = c.KobiHizmets.Where(x => x.KobiHizmetId == kbh.KobiHizmetId).Select(x => x.KobiId).FirstOrDefault();
            var value = c.KobiHizmets.Find(kbh.KobiHizmetId);
            value.AnaHizmetId = kbh.AnaHizmetId;
            value.AltHizmetId = kbh.AltHizmetId;
            value.DosyaAdi = kbh.DosyaAdi;
            value.AnlasmaSekli = kbh.AnlasmaSekli;
            value.DosyaDurumu = kbh.DosyaDurumu;
            value.ServiceSituationId = kbh.ServiceSituationId;
            c.SaveChanges();
            return Redirect($"/KobiDetail/Index/{KobiId}");
        }

        public IActionResult UpdateFileInfo(Dosya dosya)
        {
            var kobiHizmetId = dosya.KobiHizmetId;
            var value = c.Dosyas.Find(dosya.Id);
            value.DosyaAdi = dosya.DosyaAdi;
            c.SaveChanges();
            return Redirect("Index/"+kobiHizmetId);
        }
    }
}
