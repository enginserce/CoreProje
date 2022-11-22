using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
        public IActionResult Details(int id)
        {
            var values = cm.GetList(id);
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var values = cm.GetId(id);
            cm.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
