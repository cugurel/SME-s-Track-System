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
    public class KobiDetailController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        Context c = new Context();
        public KobiDetailController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(int id)
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
            ViewBag.vl3 = id;



            KobilerveHizmetler kbh = new KobilerveHizmetler();
            kbh.Kobiler = c.Kobis.Where(x => x.KobiId == id).ToList();
            kbh.KobiHizmetler = c.KobiHizmets.Where(x => x.KobiId == id).ToList();
            kbh.KobiOzelDosyas = c.KobiOzelDosyas.Where(x => x.KobiId == id).ToList();
            return View(kbh);
        }

        [HttpPost]
        public IActionResult HizmetOlustur(KobiHizmet kh)
        {
            c.KobiHizmets.Add(kh);
            c.SaveChanges();
            return Redirect($"Index/{kh.KobiId}");
        }

        

        [HttpGet]
        public IActionResult KobiOzelDosya(int id)
        {
            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            ViewBag.value = id;
            return View();
        }

        [HttpPost]
        public IActionResult UploadDocument(UploadKobiDosyaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geçersiz veri");
            }

            var document = new KobiOzelDosya
            {
                DosyaAdi = model.DosyaAdi,
                KobiId = model.KobiId,
                UniqueId = Guid.NewGuid().ToString()


            };

            document.UniqueId += Path.GetExtension(model.Dosya.FileName);
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Files");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            int kobiId = model.KobiId;

            path = Path.Combine(path, document.UniqueId);

            FileStream fs = new FileStream(path, FileMode.Create);
            model.Dosya.CopyTo(fs);
            fs.Close();

            c.KobiOzelDosyas.Add(document);
            c.SaveChanges();

            return Redirect($"Index/{kobiId}");
        }
    }
}
