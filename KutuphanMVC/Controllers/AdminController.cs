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

    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly KutuphanContext _context;

        public AdminController(ILogger<AdminController> logger, KutuphanContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Kisiler()
        {
            var value = _context.kullanicis.ToList();
            return View(value);
        }
        public IActionResult KisiEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KisiEkle(Kullanici k)
        {

            _context.kullanicis.Add(k);
            _context.SaveChanges();
            if (k.KullaniciRol != null)
            {
                string? kokDizini = Directory.GetCurrentDirectory();
                string? kayitDizini = Path.Combine(kokDizini, "wwwrot", "resim");
                string? dosyaAdi = Guid.NewGuid + Path.GetExtension(k.KullaniciRol.FileName);
                var tamYol = Path.Combine(kayitDizini, dosyaAdi);
                var dosyaAkisi = new FileStream(tamYol, FileMode.Create);
                k.KullaniciRol.CopyTo(dosyaAkisi);

                k.Resimadi = dosyaAdi;

                return RedirectToAction("Kisiler");
            }
            return RedirectToAction("Kisiler");
        }
        public IActionResult KisiDetay(int id)
        {
            var deger = _context.kullanicis.SingleOrDefault(x=> x.KullaniciId == id);
            return View(deger);
        }
        [HttpGet]
        public IActionResult KisiGuncelle(int id)
        {
            var deger = _context.kullanicis.SingleOrDefault(x=> x.KullaniciId == id);
            return View(deger);
        }
          [HttpPost]
        public IActionResult KisiGuncelle(Kullanici k)
        {
            var deger = _context.kullanicis.SingleOrDefault(x=> x.KullaniciId == k.KullaniciId);
            deger.KullaniciAd = k.KullaniciAd;
            deger.KullaniciSifre = k.KullaniciSifre;
            deger.KullaniciEmail = k.KullaniciEmail;
            deger.KullaniciTel = k.KullaniciTel;
            if (k.KullaniciRol != null)
            {
                string? kokDizini = Directory.GetCurrentDirectory();
                string? kayitDizini = Path.Combine(kokDizini, "wwwrot", "resim");
                string? dosyaAdi = Guid.NewGuid + Path.GetExtension(k.KullaniciRol.FileName);
                var tamYol = Path.Combine(kayitDizini, dosyaAdi);
                var dosyaAkisi = new FileStream(tamYol, FileMode.Create);
                k.KullaniciRol.CopyTo(dosyaAkisi);

                deger.Resimadi = dosyaAdi;
              
                _context.SaveChanges();
                return RedirectToAction("Kisiler");
            }
            
            _context.SaveChanges();
            return RedirectToAction("Kisiler");
        } 
        public IActionResult KisiSil(int id)
        {
          
            var deger = _context.kullanicis.SingleOrDefault(x=> x.KullaniciId == id);
            _context.kullanicis.Remove(deger);
            _context.SaveChanges();
            return RedirectToAction("Kisiler");
        }
        [HttpGet]
        public IActionResult Kitaplar()
        {
            var value = _context.kitaps.ToList();
            return View(value);
        }
        public IActionResult KitapEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KitapEkle(Kitap k)
        {
           _context.kitaps.Add(k);
           
            if (k.KapakFoto != null)
            {
                string? kokDizini = Directory.GetCurrentDirectory();
                string? kayitDizini = Path.Combine(kokDizini, "wwwrot", "resim");
                string? dosyaAdi = Guid.NewGuid + Path.GetExtension(k.KapakFoto.FileName);
                var tamYol = Path.Combine(kayitDizini, dosyaAdi);
                var dosyaAkisi = new FileStream(tamYol, FileMode.Create);
                k.KapakFoto.CopyTo(dosyaAkisi);

                k.Kresimad = dosyaAdi;
                 _context.SaveChanges();

                return RedirectToAction("Kitaplar");
            }
             _context.SaveChanges();
            return RedirectToAction("Kitaplar");
        }
        public IActionResult KitapDetay(int id)
        {
            var deger = _context.kitaps.SingleOrDefault(x => x.KitapId == id);
            return View(deger);
        }
        public IActionResult KitapSil(int id)
        {
            var deger = _context.kitaps.SingleOrDefault(x => x.KitapId == id);
            _context.kitaps.Remove(deger);
            _context.SaveChanges();
            return RedirectToAction("Kitaplar");
        }
        [HttpGet]
        public IActionResult KitapGuncelle(int id)
        {
            var deger = _context.kitaps.SingleOrDefault(x => x.KitapId == id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult KitapGuncelle(Kitap k)
        {


            var deger = _context.kitaps.SingleOrDefault(x => x.KitapId == k.KitapId);
            if (deger != null)
            {


                deger.KitapAd = k.KitapAd;
                deger.YazarAd = k.YazarAd;
                deger.Yayinevi = k.Yayinevi;
                deger.KitapTuru = k.KitapTuru;
                deger.KitapSayfaSayisi = k.KitapSayfaSayisi;
                if (k.KapakFoto != null)
                {
                    string? kokDizini = Directory.GetCurrentDirectory();
                    string? kayitDizini = Path.Combine(kokDizini, "wwwrot", "resim");
                    string? dosyaAdi = Guid.NewGuid + Path.GetExtension(k.KapakFoto.FileName);
                    var tamYol = Path.Combine(kayitDizini, dosyaAdi);
                    var dosyaAkisi = new FileStream(tamYol, FileMode.Create);
                    k.KapakFoto.CopyTo(dosyaAkisi);

                    deger.Kresimad = dosyaAdi;
                    _context.SaveChanges();

                    return RedirectToAction("Kitaplar");
                }
                _context.SaveChanges();
                return RedirectToAction("Kitaplar");
            }
            return RedirectToAction("Kitaplar");
        }
   

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View("Error!");
            }
        }
    }