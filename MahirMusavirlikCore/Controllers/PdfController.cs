using MahirMusavirlikCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace MahirMusavirlikCore.Controllers
{
    public class PdfController : Controller
    {
        readonly IGeneratePdf _generatePdf;

        Context c = new Context();
        public PdfController(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }


        public IActionResult GetKobiList()
        {
            var values = c.Kobis.ToList();

            return (IActionResult)_generatePdf.GetPdf("Views/Pdf/KobiInfo.cshtml", values);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
