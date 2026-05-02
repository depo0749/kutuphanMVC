using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanMVC.Models
{
    public class Kitap
    {
         [Key]
        public int KitapId { get; set; }
        public string? KitapAd { get; set; }
        public string? YazarAd { get; set; }
        public string? Yayinevi { get; set; }

        public string? KitapTuru { get; set; }
        public string? KitapSayfaSayisi { get; set; }
        public string? Kresimad { get; set; }

        [NotMapped]
        public FormFile? KapakFoto { get; set; }
        
    }
}