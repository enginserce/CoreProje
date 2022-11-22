using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System;
using X.PagedList;
using FluentValidation.Results;
using DataAccessLayer.Concrete;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetList().ToPagedList(page,3);
            return View(values);
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus = true;
                cm.TAdd(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var values = cm.GetId(id);
            cm.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = cm.GetId(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            category.CategoryStatus = true;
            cm.TUpdate(category);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToTrue(int id)
        {
            cm.TChangeToTrueCategory(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToFalse(int id)
        {
            cm.TChangeToFalseCategory(id);
            return RedirectToAction("Index");
        }

    }
}
