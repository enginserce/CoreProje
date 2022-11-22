using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProje.Areas.Admin.ViewComponents.Messages
{
    public class Messages : ViewComponent
    {
        Context c = new Context();
        MessageManager mm = new MessageManager(new EfMessagesRepository());
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetInboxWithMessageByWriter(userID);
            ViewBag.message = values.Count();
            return View(values);
        }
    }
}
