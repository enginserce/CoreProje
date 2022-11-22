using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
	[AllowAnonymous]
	public class AboutController : Controller
	{
		AboutManager am = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
            var values = am.GetList();
            return PartialView(values);
        }

		public PartialViewResult SocialMedyaAbout()
		{
			return PartialView();
		}
	}
}
