using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreProje.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProje.Controllers
{
    public class WriterController : Controller
    {
        WritterManager wm = new WritterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());

        private readonly UserManager<AppUser> _userManager;

        Context c = new Context();

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateModelView model = new UserUpdateModelView();
            model.NameSurname = values.NameSurname;
            model.UserName = values.UserName;
            model.Mail = values.Email;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateModelView model)
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
                    return RedirectToAction("WriterEditProfile", "Writer");
                }
                if (!model.ChangePassword)
                {
                    values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
                }
                var result = await _userManager.UpdateAsync(values);
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> WriterAdd(AddProfileImage p)
        {
            AppUser user = new AppUser()
            {
                Email = p.Mail,
                UserName = p.UserName,
                NameSurname = p.nameSurname,
            };

            if (p.imageUrl != null)
            {
                var extension = Path.GetExtension(p.imageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.imageUrl.CopyTo(stream);
                user.ImageUrl = newimagename;
            }

            var result = await _userManager.CreateAsync(user, p.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            userManager.TAdd(user);
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
