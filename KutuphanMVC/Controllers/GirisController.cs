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

    public class GirisController : Controller
    {
        private readonly ILogger<GirisController> _logger;
        private readonly KutuphanContext _context;

        public GirisController(ILogger<GirisController> logger, KutuphanContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult KLogin()
        {
            return View();

        }
        [HttpPost]
        public IActionResult KLogin(string kullaniciAdi, string sifre)
        {
            var kullanici = _context.kullanicis
                         .FirstOrDefault(k => k.KullaniciAd == kullaniciAdi && k.KullaniciSifre == sifre);
            if (kullanici != null)
            {

                return RedirectToAction("KBilgi", "Kullanici", new { id = kullanici.KullaniciId });
            }

           

            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }
        public IActionResult ALogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ALogin(string adminad, string sifre)
        {
            var admin = _context.admins
                             .FirstOrDefault(k => k.ADminAd == adminad && k.AdminSifre == sifre);

            if (admin != null)
            {
                return RedirectToAction("Kisiler", "Admin", new { id = admin.AdminId });
            }

            ViewBag.Hata = "Admin adı veya şifre hatalı!";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}