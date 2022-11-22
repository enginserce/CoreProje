using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProje.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            ViewBag.nameSurname = c.Users.Where(x => x.Id == userID).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.userImage = c.Users.Where(x => x.Id == userID).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.userPhone = c.Users.Where(x => x.Id == userID).Select(y => y.PhoneNumber).FirstOrDefault();
            ViewBag.userMail = c.Users.Where(x => x.Id == userID).Select(y => y.Email).FirstOrDefault();
            ViewBag.userName = c.Users.Where(x => x.Id == userID).Select(y => y.UserName).FirstOrDefault();
            ViewBag.message = c.Contacts.Count();
            return View();
        }
    }
}
