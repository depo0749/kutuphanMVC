using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphanMVC.Models
{
    public class Mesaj
    {
        [Key]
        public int MesajId { get; set; }
        public string? MesajGonderen { get; set; }
        public string? MesajKonu { get; set; }  
        public string? MesajMesaj { get; set; }
    }
}