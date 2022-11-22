using BusinessLayer.Concrete;
using CoreProje.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("/Admin/Settings")]
    public class SettingsController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());

        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateModelView model = new UserUpdateModelView();
            model.NameSurname = values.NameSurname;
            model.UserName = values.UserName;
            model.Mail = values.Email;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserUpdateModelView model)
        {
            if (ModelState.IsValid)
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                values.NameSurname = model.NameSurname;
                values.UserName = model.UserName;
                values.Email = model.Mail;

                if (model.imageUrl != null)
                {
                    var extension = Path.GetExtension(model.imageUrl.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    model.imageUrl.CopyTo(stream);
                    values.ImageUrl = newimagename;
                }

                if (model.Password == null)
                {
                    return RedirectToAction("Index", "Settings");
                }
                if (!model.ChangePassword)
                {
                    values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
                }
               
                var result = await _userManager.UpdateAsync(values);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
