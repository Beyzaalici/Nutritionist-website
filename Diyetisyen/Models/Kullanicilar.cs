using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diyetisyen.Models
{
    public class Kullanicilar
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string Sifre { get; set; }
        public string Email { get; set; }


        public int Rol { get; set; }

    }
}
