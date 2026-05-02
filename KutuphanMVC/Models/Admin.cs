using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanMVC.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string? ADminAd { get; set; }
        public string? AdminSifre { get; set; }
    }
}