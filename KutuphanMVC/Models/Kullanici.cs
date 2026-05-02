using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanMVC.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }
        public string? KullaniciAd { get; set; }
        public string? KullaniciSifre { get; set; }
        public string? KullaniciEmail { get; set; }
        public string? KullaniciTel { get; set; }
        public string? Resimadi { get; set; }
        [NotMapped]
        public FormFile? KullaniciRol { get; set; }
    }
}