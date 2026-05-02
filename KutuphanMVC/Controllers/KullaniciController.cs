using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KutuphanMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KutuphanMVC.Controllers
{

    public class KullaniciController : Controller
    {
        private readonly ILogger<KullaniciController> _logger;
        private readonly KutuphanContext _context;

        public KullaniciController(ILogger<KullaniciController> logger, KutuphanContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Kitaplar(int id)
        {
            var value = _context.kitaps.ToList();
            var kullanici = _context.kullanicis.SingleOrDefault(x => x.KullaniciId == id);
            ViewBag.kullanici = kullanici;
            return View(value);
        }
        public IActionResult KBilgi(int id)
        {

            var kullanici = _context.kullanicis.SingleOrDefault(x => x.KullaniciId == id);
            ViewBag.kullanici = kullanici;
            return View(kullanici);
            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}