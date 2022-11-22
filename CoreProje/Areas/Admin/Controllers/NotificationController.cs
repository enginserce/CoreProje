using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            var values = nm.GetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var values = nm.GetId(id);
            nm.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = nm.GetId(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Notification notification)
        {
            notification.NotificationStatus = true;
            notification.NotificationDate = Convert.ToDateTime(notification.NotificationDate);
            nm.TUpdate(notification);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Notification notification)
        {
            notification.NotificationStatus = true;
            nm.TAdd(notification);
            return RedirectToAction("Index", "Notification");
        }
    }
}
