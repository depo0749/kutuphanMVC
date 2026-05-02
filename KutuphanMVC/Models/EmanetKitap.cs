using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanMVC.Models
{
    public class EmanetKitap
    {
        [Key]
        public int EmanetKitapId { get; set; }
        public int KitapId { get; set; }
        public int KullaniciId { get; set; }
    }
}