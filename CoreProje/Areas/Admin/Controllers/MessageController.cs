using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessagesRepository());
        Context c = new Context();
        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetInboxWithMessageByWriter(userID);
            var values2 = mm.GetSendboxWithMessageByWriter(userID);
            ViewBag.inboxCount = values.Count();
            ViewBag.sendboxCount = values2.Count();
            return View(values);
        }
        public IActionResult Sendbox()
        {
            var username = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetSendboxWithMessageByWriter(userID);
            var values2 = mm.GetInboxWithMessageByWriter(userID);
            ViewBag.inboxCount = values2.Count();
            ViewBag.sendboxCount = values.Count();
            return View(values);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            p.SenderID = userID;
            p.ReceiverID = 2;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            p.MessageStatus = true;
            mm.TAdd(p);
            return RedirectToAction("Sendbox", "Message", new { area = "Admin" });
        }
        public PartialViewResult LeftBar()
        {
            return PartialView();
        }
        public IActionResult Details(int id)
        {
            var value = mm.GetMessageById(id);
            return View(value);
        }

        public IActionResult Delete(int id)
        {
            var values = mm.GetId(id);
            mm.TDelete(values);
            return RedirectToAction("Inbox", "Message", new { area = "Admin" });
        }
    }
}
