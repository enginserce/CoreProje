using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreProje.Areas.Admin.ViewComponents.Info
{
    public class Info : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            ViewBag.nameSurname = c.Users.Where(x => x.Id == userID).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.userImage = c.Users.Where(x => x.Id == userID).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.userMail = c.Users.Where(x => x.Id == userID).Select(y => y.Email).FirstOrDefault();
            ViewBag.userName = c.Users.Where(x => x.Id == userID).Select(y => y.UserName).FirstOrDefault();
            return View();
        }
    }
}
