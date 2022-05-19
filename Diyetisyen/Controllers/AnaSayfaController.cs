using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diyetisyen.Controllers
{
    public class AnaSayfaController : Controller
    {
        public IActionResult AnaSayfa()
        {
            return View();
        }
        public IActionResult Hakkimda()
        {
            return View();
        }

        public IActionResult OnlineDiyet()
        {
            return View();
        }

        public IActionResult Hizmetlerimiz()
        {
            return View();
        }

        public IActionResult BkiHesapla()
        {
            return View();
        }

        public IActionResult KisaVeOz()
        {
            return View();
        }
    }

}
