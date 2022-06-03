using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Diyetisyen.Data;
using Diyetisyen.Models;

namespace Diyetisyen.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GirisController : Controller
    {
        private readonly DiyetisyenContext db;

        public GirisController(DiyetisyenContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }
        public async Task<IActionResult> Giris(Kullanicilar kullanicilar)
        {

            return View();
        }


        [HttpPost]

        public async Task<JsonResult> GirisSorgula([FromBody] Kullanicilar data)
        {
            string Email = data.Email;
            string Sifre = data.Sifre;
            try
            {

                if (String.IsNullOrEmpty(Sifre) && String.IsNullOrEmpty(Email))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı ve Şifrenizi Girmediniz!" });
                }
                else if (String.IsNullOrEmpty(Email))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı girmediniz!" });
                }
                else if (String.IsNullOrEmpty(Sifre))
                {
                    return Json(new { Result = false, Message = "Şifrenizi Girmediniz!" });
                }
                else
                {

                    var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Email == Email && x.Sifre == Sifre && x.Rol == 1);

                    if (kullanici == null) return Json(new { Result = false, Message = "Kullanıcı Adınızı ya da Şifreyi hatalı girdiniz!" });

                    var claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name,data.Email)
                };
                    var userIdentity = new ClaimsIdentity(claims, "Giris");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    return Json(new { Result = true, Message = "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz...", url = "../Kategori/KategoriAdmin" });

                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }

        }
        [HttpGet]
        public async Task<IActionResult> OturumuKapat()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return View("Giris");


        }


    }
}

