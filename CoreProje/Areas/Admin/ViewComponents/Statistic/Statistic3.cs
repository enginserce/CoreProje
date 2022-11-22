using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProje.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic3 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.userCount = c.Users.Count();
            ViewBag.adminCount = c.UserRoles.Where(x=> x.RoleId == 1).Count();
            ViewBag.writerCount = c.UserRoles.Where(x=> x.RoleId == 2).Count();
            ViewBag.moderatorCount = c.UserRoles.Where(x=> x.RoleId == 4).Count();
            ViewBag.memberCount = c.UserRoles.Where(x=> x.RoleId == 3).Count();
            ViewBag.scoreCount = c.Comments.Select(x => x.BlogScore).Sum();
            return View();
        }
    }
}
