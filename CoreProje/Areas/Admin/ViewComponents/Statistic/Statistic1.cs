using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreProje.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.blogCount = bm.GetList().Count();
            ViewBag.contectCount = c.Contacts.Count();
            ViewBag.commentCount = c.Comments.Count();
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=f882b3042eb7cb6a005e8fccb6305b3a";
            XDocument document = XDocument.Load(connection);
            ViewBag.istanbul = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
