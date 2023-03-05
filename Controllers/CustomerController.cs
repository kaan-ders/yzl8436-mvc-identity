using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class CustomerController : Controller
    {
        //listeleme, satış temsilcisi ve muhasebe

        [Authorize(Roles = "SatisTemsilcisi,Finans")]
        public IActionResult Index()
        {
            //kullanıcı rolid, rol 
            return View();
        }

        //ekleme, satış temsilcisi
        [Authorize(Roles = "SatisTemsilcisi")]
        public IActionResult Add()
        {
            //var user = "select * from kullanici where rolid=2 and id=o an giriş yapan kullanıcı idsi"
            return View();
        }

        //güncelle, satış temsilcisi
        [Authorize(Roles = "SatisTemsilcisi")]
        public IActionResult Update()
        {
            return View();
        }

        //sil, satış temsilcisi
        [Authorize(Roles = "SatisTemsilcisi")]
        public IActionResult Delete()
        {
            //silme işlemi
            return RedirectToAction("Index");
        }
    }
}
