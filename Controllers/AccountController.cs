using Identity.Models;
using Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Kullanici> _signInManager;
        private readonly UserManager<Kullanici> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<Kullanici> signInManager, 
            UserManager<Kullanici> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                //login yap
                var result = _signInManager.PasswordSignInAsync(model.Email, model.Sifre, model.BeniHatirla, lockoutOnFailure: false).Result;
                if(result.Succeeded)
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.Hata = "Hatalı kullanıcı adı veya şifre";
                    return View();
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                Kullanici kullanici = new Kullanici
                {
                   UserName = model.Email,
                   Email = model.Email,
                   AdiSoyadi = model.AdiSoyadi
                };

                var result = _userManager.CreateAsync(kullanici, model.Sifre).Result;
                if(result.Succeeded)
                {
                    var res = _userManager.AddToRoleAsync(kullanici, model.Role).Result;
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Hata = "Hatalı kullanıcı bilgisi";
                    return View();
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            await _roleManager.CreateAsync(new IdentityRole("SatisTemsilcisi"));
            await _roleManager.CreateAsync(new IdentityRole("Finans"));

            return RedirectToAction("Index");
        }
    }
}
