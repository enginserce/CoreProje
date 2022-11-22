using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
	[AllowAnonymous]
	public class NewsletterController : Controller
	{
		NewslatterManager nm = new NewslatterManager(new EfNewsletterRepository());

		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}
		[HttpPost]
        public IActionResult SubscribeMail(Newsletter newsletter)
        {
			newsletter.MailStatus = true;
			nm.NewsletterAdd(newsletter);
            return RedirectToAction("Index", "Blog");
        }

    }
}


