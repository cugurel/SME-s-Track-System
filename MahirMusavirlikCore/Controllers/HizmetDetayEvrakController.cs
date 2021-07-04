﻿using MahirMusavirlikCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MahirMusavirlikCore.Controllers
{
    [Authorize]
    public class HizmetDetayEvrakController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        Context c = new Context();
        public HizmetDetayEvrakController(IHostingEnvironment hostingEnvironment)
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

            var values = c.HizmetDetayDokumans.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult DosyaEkle()
        {
            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            return View();
        }

        [HttpPost]
        public IActionResult UploadDocument(UploadHizmetDetayModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geçersiz veri");
            }

            var document = new HizmetDetayDokuman
            {
                DosyaAdi = model.DosyaAdi,
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

            c.HizmetDetayDokumans.Add(document);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteFile(string ui)
        {

            var document = c.HizmetDetayDokumans.FirstOrDefault(x => x.UniqueId == ui);
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Files", document.UniqueId);

            c.HizmetDetayDokumans.Remove(document);
            c.SaveChanges();

            System.IO.File.Delete(path);
            return Redirect("Index");
        }

        public IActionResult GetHizmetDetayEvrak(int id)
        {
            ViewBag.countedKobis = c.Kobis.Where(x => x.SituationId == 1).Count();
            ViewBag.countedHizmet = c.KobiHizmets.Count();
            ViewBag.countedFile = c.Dosyas.Count();
            ViewBag.aktifDokuman = c.AktifDokumans.Count();
            ViewBag.sozlesme = c.Sozlesmes.Count();

            var value = c.HizmetDetayDokumans.Find(id);
            return View("GetHizmetDetayEvrak", value);
        }

        public IActionResult UpdateHizmetDetay(HizmetDetayDokuman hizmetDetayDokuman)
        {
            var value = c.HizmetDetayDokumans.Find(hizmetDetayDokuman.Id);
            value.DosyaAdi = hizmetDetayDokuman.DosyaAdi;
            value.DosyaTarihi = hizmetDetayDokuman.DosyaTarihi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

