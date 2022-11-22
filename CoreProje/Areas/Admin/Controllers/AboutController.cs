using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager ab = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var values = ab.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = ab.GetId(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(About about)
        {
            about.AboutStatus = true;
            ab.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}
